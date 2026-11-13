using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MyLibrary
{
    public static class FileUtils
    {

        public static void CopyFile(string sourcePath, string destPath)
        {
            
            File.Copy(sourcePath, destPath, true); 
        }

        
        public static void CopyDirectory(string sourceDir, string destDir)
        {
            
            DirectoryInfo dir = new DirectoryInfo(sourceDir);
            if (!dir.Exists)
                throw new DirectoryNotFoundException("Исходная папка не найдена: " + sourceDir);

            
            Directory.CreateDirectory(destDir);
        
            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destDir, file.Name);
                file.CopyTo(targetFilePath, true);
            }

            
            foreach (DirectoryInfo subDir in dir.GetDirectories())
            {
                string newDestDir = Path.Combine(destDir, subDir.Name);
                CopyDirectory(subDir.FullName, newDestDir); // Вызов самого себя (рекурсия)
            }
        }

        
        public static void DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
                File.Delete(filePath);
        }
        public static void DeleteFilesByNames(string directory, IEnumerable<string> fileNames)
        {
            foreach (string fileName in fileNames)
            {
 
                string fullPath = Path.Combine(directory, fileName);
                if (File.Exists(fullPath))
                    File.Delete(fullPath);
            }
        }

        public static void DeleteFilesByMask(string directory, string mask)
        {
            // GetFiles сам находит файлы по маске
            string[] files = Directory.GetFiles(directory, mask);
            foreach (string file in files)
            {
                File.Delete(file);
            }
        }
        public static void MoveFile(string sourcePath, string destPath)
        {
            File.Move(sourcePath, destPath);
        }

        public static void SearchWordInFile(string filePath, string word, string reportPath)
        {
            if (!File.Exists(filePath)) return;


            string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);
            StringBuilder report = new StringBuilder();
            
            report.AppendLine($"--- Отчет по файлу: {Path.GetFileName(filePath)} ---");
            int count = 0;

            for (int i = 0; i < lines.Length; i++)
            {

                if (lines[i].IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    count++;
                    report.AppendLine($"Строка {i + 1}: {lines[i].Trim()}");
                }
            }

            report.AppendLine($"Найдено совпадений: {count}\n");
            File.AppendAllText(reportPath, report.ToString(), Encoding.UTF8);
        }

        public static void SearchWordInFolder(string folderPath, string word, string reportPath)
        {

            File.WriteAllText(reportPath, $" '{word}' В ПАПКЕ {folderPath}");


            string[] files = Directory.GetFiles(folderPath);

            foreach (string file in files)
            {

                SearchWordInFile(file, word, reportPath);
            }
            
        }
    }
}
