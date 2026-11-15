using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeAnalyzer
{
    public static class ResumeParser
    {
        public static async Task<List<Resume>> LoadResumesAsync(string[] filePaths)
        {
            var resumes = new ConcurrentBag<Resume>();

            await Task.Run(() =>
            {
                Parallel.ForEach(filePaths, filePath =>
                {
                    try
                    {
                        Resume resume = ParseFile(filePath);
                        if (resume != null)
                        {
                            resumes.Add(resume);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка при загрузке {filePath}: {ex.Message}");
                    }
                });
            });

            return resumes.ToList();
        }

        private static Resume ParseFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            
            if (lines.Length < 6)
                return null;

            Resume resume = new Resume
            {
                FilePath = filePath,
                Name = ExtractValue(lines[0], "Имя:"),
                City = ExtractValue(lines[1], "Город:"),
                ExperienceYears = ExtractIntValue(lines[2], "Опыт работы (лет):"),
                Salary = ExtractIntValue(lines[3], "Зарплата (руб):"),
                Phone = ExtractValue(lines[4], "Телефон:"),
                Email = ExtractValue(lines[5], "Email:")
            };

            return resume;
        }


        private static string ExtractValue(string line, string key)
        {
            if (line.StartsWith(key))
            {
                return line.Substring(key.Length).Trim();
            }
            return "";
        }


        private static int ExtractIntValue(string line, string key)
        {
            string value = ExtractValue(line, key);
            if (int.TryParse(value, out int result))
            {
                return result;
            }
            return 0;
        }
    }
}
