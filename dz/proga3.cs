using System.Diagnostics;
using System.Drawing;
using System.Linq.Expressions;

namespace MyNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1.Расстояние между точками ввод(x1,x2,y1,y2) 
            // ==============================================================
            Console.Write("Введите x1: ");
            double x1 = double.Parse(Console.ReadLine());

            Console.Write("Введите x2: ");
            double x2 = double.Parse(Console.ReadLine());

            Console.Write("Введите y1: ");
            double y1 = double.Parse(Console.ReadLine());

            Console.Write("Введите y2: ");
            double y2 = double.Parse(Console.ReadLine());

            // Формула: ((x2 - x1)² + (y2 - y1)²)
            double distance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));

            Console.WriteLine($"Расстояние: {distance:F2}");
            
            // 2. Сумма цифр числа (999 = 9+9+9)
            //============================================================
            Console.Write("Введите целое число: ");
            int num = Math.Abs(int.Parse(Console.ReadLine())); 
            int sum = 0;
            int temp = num;

            while (temp > 0)
            {
                sum += temp % 10; 
                temp /= 10;       
            }
            Console.WriteLine($"Сумма цифр числа = {sum}");
            
            // 3.Генератор массива случайных чисел (кол-во ячеек массива, от n, до n)
            // Все сделать в функции, ввод от пользователя*/
            ////////////////////////////////////////////////////////////////////////
            Console.Write("введите количество ячеек массива  ");
            int size = int.Parse(Console.ReadLine());
            Console.Write("Минимальное число: ");
            int min = int.Parse(Console.ReadLine());
            Console.Write("Максимальное число: ");
            int max = int.Parse(Console.ReadLine());
            
            Random random = new Random();
            int[] array = new int[size];
            
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(min, max + 1);
            }
            Console.WriteLine("Результат: [" + string.Join(", ", array) + "]");
        }
    }
}

/*1.Расстояние между точками ввод(x1,x2,y1,y2)
2. Сумма цифр числа (999 = 9+9+9)
3.Генератор массива случайных чисел (кол-во ячеек массива, от n, до n)
Все сделать в функции, ввод от пользователя*/
