using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskDZ
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
            btnCancel.Enabled = false;
        }

        
        private void btnBrowseSource_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtSource.Text = folderBrowserDialog.SelectedPath;
            }
        }

        
        private void btnBrowseDestination_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtDestination.Text = folderBrowserDialog.SelectedPath;
            }
        }

        
        private async void btnStart_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(txtSource.Text) || !Directory.Exists(txtSource.Text))
            {
                MessageBox.Show("Укажите корректный путь", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDestination.Text))
            {
                MessageBox.Show("Укажите путь к приёмнику", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            /
            try
            {
                Directory.CreateDirectory(txtDestination.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnStart.Enabled = false;
            btnCancel.Enabled = true;
            txtLog.Clear();
            progressBar.Value = 0;

           
            _cancellationTokenSource = new CancellationTokenSource();

            try
            {
               
                await ProcessFilesAsync(txtSource.Text, txtDestination.Text, _cancellationTokenSource.Token);
                

            }

            catch (Exception ex)
            {

                MessageBox.Show($"{ex.Message}", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

                btnStart.Enabled = true;
                btnCancel.Enabled = false;
                _cancellationTokenSource?.Dispose();
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            _cancellationTokenSource?.Cancel();

        }


        private async Task ProcessFilesAsync(string sourceDir, string destDir, CancellationToken cancellationToken)
        {

            string[] files = Directory.GetFiles(sourceDir, "*", SearchOption.AllDirectories);
            
            if (files.Length == 0)
            {
                AppendLog("В источнике нет файлов.");
                return;
            }

            AppendLog($"Найдено файлов: {files.Length}\n");


            var hashToFiles = new ConcurrentDictionary<string, List<string>>();
            var processedFiles = new ConcurrentBag<FileResult>();


            int processedCount = 0;
            int totalFiles = files.Length;

            await Task.Run(() =>
            {
                Parallel.ForEach(files, new ParallelOptions { CancellationToken = cancellationToken }, file =>
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    try
                    {

                        string hash = ComputeFileHash(file);


                        var fileList = hashToFiles.GetOrAdd(hash, _ => new List<string>());
                        lock (fileList) 
                        {
                            fileList.Add(file);
                        }

      
                        int current = Interlocked.Increment(ref processedCount);
                        int percent = (current * 100) / totalFiles;


                        if (current % Math.Max(1, totalFiles / 10) == 0)
                        {
                            AppendLog($"{current}/{totalFiles} ({percent}%)");
                        }
                    }
                    catch (Exception ex)
                    {
                        processedFiles.Add(new FileResult(file, FileStatus.Error, $"Ошибка: {ex.Message}"));
                    }
                });
            }, cancellationToken);

    
            // двойники 
            foreach (var kvp in hashToFiles)
            {
                cancellationToken.ThrowIfCancellationRequested();

                string hash = kvp.Key;
                List<string> fileList = kvp.Value;

                if (fileList.Count == 1)
                {
                    //оригинал
                    processedFiles.Add(new FileResult(fileList[0], FileStatus.Original, "Оригинал"));
                }
                else
                {
                    //двойник
                    processedFiles.Add(new FileResult(fileList[0], FileStatus.Original, "Оригинал"));
                    
                    for (int i = 1; i < fileList.Count; i++)
                    {
                        processedFiles.Add(new FileResult(fileList[i], FileStatus.Duplicate, "Двойник"));
                    }
                }
            }


            int originalsCount = processedFiles.Count(r => r.Status == FileStatus.Original);
            int duplicatesCount = processedFiles.Count(r => r.Status == FileStatus.Duplicate);


            AppendLog($"  Оригиналов: {originalsCount}");
            AppendLog($"  Двойников: {duplicatesCount}");

            int movedCount = 0;

            foreach (var result in processedFiles.Where(f => f.Status == FileStatus.Original))
            {
                cancellationToken.ThrowIfCancellationRequested();

                try
                {

                    string relativePath = Path.GetRelativePath(sourceDir, result.FilePath);
                    string destPath = Path.Combine(destDir, relativePath);
                    string destDirectory = Path.GetDirectoryName(destPath);
                    Directory.CreateDirectory(destDirectory);
                    File.Move(result.FilePath, destPath, true);
                    movedCount++;

                    AppendLog($"  {Path.GetFileName(result.FilePath)}");
                }
                catch (Exception ex)
                {
                    result.Status = FileStatus.Error;
                    result.Message = $"Ошибка перемещения: {ex.Message}";
                    AppendLog($" {Path.GetFileName(result.FilePath)} — {ex.Message}");
                }
            }

            AppendLog($"\nПеремещено оригиналов: {movedCount}");

);
            string reportPath = Path.Combine(destDir, "report.txt");
            GenerateReport(reportPath, processedFiles.ToList());
            AppendLog($"Отчёт сохранён: {reportPath}");
        }

        private string ComputeFileHash(string filePath)
        {
            using (var sha256 = SHA256.Create())
            using (var stream = File.OpenRead(filePath))
            {
                byte[] hash = sha256.ComputeHash(stream);
                return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
            }
        }


        private void GenerateReport(string reportPath, List<FileResult> results)
        {
            using (StreamWriter writer = new StreamWriter(reportPath))
            {
                writer.WriteLine($"Всего файлов: {results.Count}");
                writer.WriteLine($"Оригиналов: {results.Count(r => r.Status == FileStatus.Original)}");
                writer.WriteLine($"Двойников: {results.Count(r => r.Status == FileStatus.Duplicate)}");
                writer.WriteLine($"Ошибок: {results.Count(r => r.Status == FileStatus.Error)}");
                writer.WriteLine();

 
            }

      
        }


    public class FileResult
    {
        public string FilePath { get; }
        public FileStatus Status { get; set; }
        public string Message { get; set; }

        public FileResult(string filePath, FileStatus status, string message)
        {
            FilePath = filePath;
            Status = status;
            Message = message;
        }
    }

    public enum FileStatus
    {
        Original,    
        Duplicate,   
        Error        
    }
}
