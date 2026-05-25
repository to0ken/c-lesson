
using System.Diagnostics;
using System.Drawing;
using System.Linq.Expressions;

namespace progg
{
    internal class Program
    {
        // -----------------------------2 ---------------------------------
        // Collect - процесс автоматического освобождения памяти от объектов, которые больше не используются в программе.
        // CollectionCount - Возвращает количество раз, когда выполнялась сборка мусора для указанного поколения объектов.
        // GetTotalMemory - 



        // ---------------------------- 1 ---------------------------------
        static void Main(string[] args)
        {

            // -----------------------------2 ---------------------------------
            string[] colections = { "Футболка", "Штаны", "Пальто", "Арбуз", "Банан" };
            Array.Sort(colections);

            foreach (string colection in colections )
            {
                Console.WriteLine(" " + colection);
            }
            GC.Collect();
            GC.GetTotalMemory(true);
            Console.WriteLine($"{GC.CollectionCount(0)}, {GC.CollectionCount(1)}, {GC.CollectionCount(2)}" );
            Console.WriteLine($"{GC.GetTotalMemory}");

            // ==============================================================================j

            /*Console.WriteLine("введите 1 числ:");
            double num1 = double.Parse(Console.ReadLine());

            Console.WriteLine("введите 2 числ:");
            double num2 = double.Parse(Console.ReadLine());

            Console.WriteLine(" выберите (+, -, /):");
            char mathSign = Console.ReadLine()[0];
            if (mathSign == '+')
            {
                Console.WriteLine(num1 + num2);
            }
            else if (mathSign == '-')
            {
                Console.WriteLine(num1 - num2);
            }
            else if (mathSign == '/')
            {
                Console.WriteLine(num1 / num2);
            }
            else
            {
                Console.WriteLine("введите коректный символ");
                return;
            }
            GC.Collect();*/

        }
    }

}


