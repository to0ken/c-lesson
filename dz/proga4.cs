using System.Diagnostics;
using System.Drawing;
using System.Linq.Expressions;

namespace MyNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            
                
            //1 Сортировка массива строк по последней букве
            // ================================================================
            string[] words = { "облако", "бежать", "синий", "музыка", "тишина" };
            Array.Sort(words, (a, b) => a[^1].CompareTo(b[^1])); 

            Console.WriteLine(string.Join(", ", words));
            
            //2Из массива строк в котором находятся и строки и числа(string) суммировать все числа
            //=========================================================================
            string[] items = { "яблоко", "100", "груша", "25", "кот", "5", "банан" };

            double sum = SumNumbers(items); 

            Console.WriteLine($" {sum}");
            

            //3  Проверить является ли число степеней двойки через вызов функции*/
            
        }
        static double SumNumbers(string[] arr)
        {
            double sum = 0;
            foreach (string item in arr)
            {
                if (double.TryParse(item, out double number))
                {
                    sum += number;
                }
            }
            return sum;
            
        }
    }
}
/*1. Сортировка массива строк по последней букве
2. Из массива строк в котором находятся и строки и числа(string) суммировать все числа
3. Проверить является ли число степеней двойки через вызов функции*/

