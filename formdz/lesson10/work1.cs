using System;
using System.IO;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.Write("Путь к файлу: ");
        string path = Console.ReadLine();

        Console.Write("Слово для поиска: ");
        string word = Console.ReadLine();


        try
        {
            string content = await File.ReadAllTextAsync(path);
            char[] separators = { ' ', '\n', '\r', '\t', '.', ',', '!', '?', ';', ':' };
            string[] words = content.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            int count = 0;
            foreach (string w in words)
            {
                if (w.Equals(word, StringComparison.OrdinalIgnoreCase))
                    count++;
            }

            Console.WriteLine($"Слово '{word}' {count} раз");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.ReadLine();
    }
}
