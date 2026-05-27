using System;
using System.IO;

//4.Отсортировать массив строк по алфавиту с помощью LINQ
class Program
{
    static void Main()
    {
        string[] words = { "яблоко", "арбуз", "банан", "кот", "дом" };
        string[] sorted = words.OrderBy(w => w).ToArray();

        Console.WriteLine(string.Join(", ", sorted));
    }

}

