using System.Diagnostics;
using System.Drawing;
using System.Linq.Expressions;

namespace MyNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1 Проверка есть ли в строке, которую вводит пользователь "a".
            string word = "Привет";
            bool hasLetter = word.Contains("а");
            Console.WriteLine(hasLetter);
            
            // 2 Проверка одинаковые ли 2 строки вводимые пользователем без учета регистрозависимости. (ААА=ааа)
            Console.Write("Введите первую строку: ");
            string strok1 = Console.ReadLine();
            Console.Write("Введите вторую строку: ");
            string strok2 = Console.ReadLine();
            bool proverk = string.Equals(strok1, strok2, StringComparison.OrdinalIgnoreCase);

            Console.WriteLine($"Строки одинаковые: {proverk}");
            
            // 3 - Вывести строку которую вводит пользователь по буквам с новой строки.
            Console.WriteLine("Введите строку:");
            string input = Console.ReadLine();
            if (input != null)
            {
                foreach (char c in input)
                {
                    Console.WriteLine(c);
                }
            }
            // 4 - Вывести каждую четный символ из строки вводимой пользоваетелем.*/
            Console.Write("Введите строку: ");
            string input1 = Console.ReadLine();

            for (int i = 1; i < input1.Length; i += 2)
            {
                Console.Write(input1[i]);
            }

            
        }
    }
}


/*1. Проверка есть ли в строке, которую вводит пользователь "a".
2. Проверка одинаковые ли 2 строки вводимые пользователем без учета регистрозависимости. (ААА=ааа)
3. Вывести строку которую вводит пользователь по буквам с новой строки.
4. Вывести каждую четный символ из строки вводимой пользоваетелем.*/

