using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResumeAnalyzer
{
    public partial class Form1 : Form
    {
        private List<Resume> resumes = new List<Resume>();

        public Form1()
        {
            InitializeComponent();
        }

        // Загрузка одного резюме
        private void btnLoadSingle_Click(object sender, EventArgs e)
        {
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadResumesAsync(openFileDialog.FileNames);
            }
        }

        // Загрузка нескольких резюме
        private void btnLoadMultiple_Click(object sender, EventArgs e)
        {
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadResumesAsync(openFileDialog.FileNames);
            }
        }

        // Загрузка всех резюме из папки
        private void btnLoadFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string[] files = Directory.GetFiles(folderBrowserDialog.SelectedPath, "*.txt");
                LoadResumesAsync(files);
            }
        }


        private async void LoadResumesAsync(string[] filePaths)
        {
            txtLog.Clear();
            txtReports.Clear();
            progressBar.Value = 0;
            btnGenerateReports.Enabled = false;

   

            try
            {
                resumes = await ResumeParser.LoadResumesAsync(filePaths);
                 
                if (resumes.Count > 0)
                {
                    btnGenerateReports.Enabled = true;
                    AppendLog("Можно формировать отчёты.");
                }
                else
                {
                    AppendLog(" Не удалось");
                }
            }
            catch (Exception ex)
            {
                AppendLog($"{ex.Message}");
            }
        }


        private async void btnGenerateReports_Click(object sender, EventArgs e)
        {
            progressBar.Value = 0;

            try
            {
                var reports = await ReportGenerator.GenerateAllReportsAsync(_resumes);


        }
    }
}
