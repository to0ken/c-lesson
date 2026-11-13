using System;
using System.Collections.Generic;
using System.IO;
using MyLibrary; // Подключаем 

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {

            string testDir = @"C:\Temp\Test";
            Directory.CreateDirectory(testDir);

            Console.WriteLine($"Email 'test@mail.com' {ValidationUtils.IsValidEmail("test@mail.com")}");
            Console.WriteLine($"Email 'invalid-email'  {ValidationUtils.IsValidEmail("invalid-email")}");
            Console.WriteLine($"Телефон '+7 (900) 123-45-67' валиден? {ValidationUtils.IsValidPhone("+7 (900) 123-45-67")}");


     
            string file1 = Path.Combine(testDir, "test1.txt");
            File.WriteAllText(file1, "Это тестовый файл.\nСлово тест встречается тут.");
            
            string file2 = Path.Combine(testDir, "test2.txt");
            File.WriteAllText(file2, "Тут тоже есть слово тест.");

            // Копируем файл
            string fileCopy = Path.Combine(testDir, "test1_copy.txt");
            FileUtils.CopyFile(file1, fileCopy);
            Console.WriteLine("Файл скопирован.");

            // Переносим файл
            string fileMoved = Path.Combine(testDir, "test1_moved.txt");
            FileUtils.MoveFile(fileCopy, fileMoved);
            Console.WriteLine("Файл перенесен.");


            string reportPath = Path.Combine(testDir, "search_report.txt");

            FileUtils.SearchWordInFile(file1, "тест", reportPath);

            FileUtils.SearchWordInFolder(testDir, "тест", reportPath);



            Console.ReadKey();
        }
    }
}
