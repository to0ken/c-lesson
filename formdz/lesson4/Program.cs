using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Ошибка: недостаточно аргументов.");

            Console.ReadLine();
            return;
        }

        string filePath = args[0];
        string word = args[1];

        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Файл не найден: {filePath}");
            Console.ReadLine();
            return;
        }

        string content = File.ReadAllText(filePath);
        
     
        char[] separators = { ' ', '\n', '\r', '\t', '.', ',', '!', '?', ';', ':' };
        string[] words = content.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        int count = 0;
        foreach (string w in words)
        {
            if (w.Equals(word, StringComparison.OrdinalIgnoreCase))
            {
                count++;
            }
        }

        Console.WriteLine($"Слово '{word}' встречается в файле {count} раз");
        Console.ReadLine();
    }
}
