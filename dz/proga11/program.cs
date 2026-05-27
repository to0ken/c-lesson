using System;
using System.IO;

// 1.Напишите программу которая просматривает есть ли заданое слово в нескольких txt файлов, и выдает true или false
class Program
{
    static void Main()
    {
        string wordToFind = "привет";
        string[] files = { "test1.txt", "test2.txt" };

        foreach (string filePath in files)
        {
            bool found = false;
        using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
             
                    if (line.Contains(wordToFind, StringComparison.OrdinalIgnoreCase))
                    {
                        found = true;
                        break; 
                    }
                }
            }
            Console.WriteLine($"{filePath}: {found}");
        }
    }
}
