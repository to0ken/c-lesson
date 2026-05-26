
using System.Diagnostics;
using System.Linq.Expressions;
using System;
using System.Linq;

// 1.Создать 3 файла cs, в которых разные части слова в строке. В мейне собрать слово целиком

class Program
{
    static void Main()
    {
        string fullWord = Part1.Text + Part2.Text + Part3.Text;
        Console.WriteLine($" {fullWord}");
    }
}
