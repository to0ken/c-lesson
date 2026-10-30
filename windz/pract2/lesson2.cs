using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp20
{
    class Program
    {
        static int[] numbers = new int[1000];

        static int max, min;
        static double avg;
        static void Main(string[] args)
        {
            Random random = new Random();
            for (int i = 0; i < 1000; i++)
                numbers[i] = random.Next(0, 1001);

            Console.WriteLine("1 - Максимум 2 - Минимум 3 - Среднее 4 - Всё сразу");
            Console.Write("Выбор: ");
            int choice = int.Parse(Console.ReadLine());

            Thread t1 = null;
            Thread t2 = null;
            Thread t3 = null;

            if (choice == 1 || choice == 4) { t1 = new Thread(FindMax); t1.Start(); }
            if (choice == 2 || choice == 4) { t2 = new Thread(FindMin); t2.Start(); }
            if (choice == 3 || choice == 4) { t3 = new Thread(FindAvg); t3.Start(); }

            if (t1 != null) t1.Join();
            if (t2 != null) t2.Join();
            if (t3 != null) t3.Join();



            using (StreamWriter sw = new StreamWriter("results.txt"))
            {
                if (choice == 1 || choice == 4) sw.WriteLine($"Максимум: {max}");
                if (choice == 2 || choice == 4) sw.WriteLine($"Минимум: {min}");
                if (choice == 3 || choice == 4) sw.WriteLine($"Среднее: {avg:F2}");
            }

            Console.WriteLine("Результаты сохранены в results.txt");
            Console.ReadLine();

        }
        static void FindMax()
        {
            max = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
                if (numbers[i] > max) max = numbers[i];
            Console.WriteLine($"Максимум: {max} (поток {Thread.CurrentThread.ManagedThreadId})");
        }

        static void FindMin()
        {
            min = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
                if (numbers[i] < min) min = numbers[i];
            Console.WriteLine($"Минимум: {min} (поток {Thread.CurrentThread.ManagedThreadId})");
        }

        static void FindAvg()
        {
            long sum = 0;
            for (int i = 0; i < numbers.Length; i++)
                sum += numbers[i];
            avg = (double)sum / numbers.Length;
            Console.WriteLine($"Среднее: {avg:F2} (поток {Thread.CurrentThread.ManagedThreadId})");
        }



    }

}
