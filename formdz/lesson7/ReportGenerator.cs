using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeAnalyzer
{
    public static class ReportGenerator
    {

        public static async Task<Dictionary<string, string> GenerateAllReportsAsync(List<Resume> resumes)
        {
            var reports = new Dictionary<string, string>();

            await Task.Run(() =>
            {

                Parallel.Invoke(
                    () => reports["Самый опытный кандидат"] = GetMostExperienced(resumes),
                    () => reports["Самый неопытный кандидат"] = GetLeastExperienced(resumes),
                    () => reports["Кандидаты из одного города"] = GetCandidatesByCity(resumes),
                    () => reports["Кандидат с самой низкой зарплатой"] = GetLowestSalary(resumes),
                    () => reports["Кандидат с самой высокой зарплатой"] = GetHighestSalary(resumes)
                );
            });

            return reports;
        }


        private static string GetMostExperienced(List<Resume> resumes)
        {

            var mostExperienced = resumes.AsParallel()
                .OrderByDescending(r => r.ExperienceYears)
                .FirstOrDefault();

            if (mostExperienced == null)
                return "Нет данных";

            return mostExperienced.ToString();
        }


        private static string GetLeastExperienced(List<Resume> resumes)
        {
            var leastExperienced = resumes.AsParallel()
                .OrderBy(r => r.ExperienceYears)
                .FirstOrDefault();

            if (leastExperienced == null)
                return "Нет данных";

            return leastExperienced.ToString();
        }


        private static string GetCandidatesByCity(List<Resume> resumes)
        {
            // Группируем по городу параллельно
            var cityGroups = resumes.AsParallel()
                .GroupBy(r => r.City)
                .OrderByDescending(g => g.Count())
                .ToList();

            if (!cityGroups.Any())
                return "Нет данных";

            var result = new System.Text.StringBuilder();
            
            foreach (var group in cityGroups)
            {
                result.AppendLine($"\n{group.Key} ({group.Count()} чел.):");
                foreach (var resume in group)
                {
                    result.AppendLine($"  {resume.Name}");
                }
            }

            return result.ToString();
        }

 
        private static string GetLowestSalary(List<Resume> resumes)
        {
            var lowestSalary = resumes.AsParallel()
                .OrderBy(r => r.Salary)
                .FirstOrDefault();

            if (lowestSalary == null)
                return "Нет данных";

            return lowestSalary.ToString();
        }


        private static string GetHighestSalary(List<Resume> resumes)
        {
            var highestSalary = resumes.AsParallel()
                .OrderByDescending(r => r.Salary)
                .FirstOrDefault();

            if (highestSalary == null)
                return "Нет данных";

            return highestSalary.ToString();
        }
    }
}
