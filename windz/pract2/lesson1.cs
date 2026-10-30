using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp19
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Console.Write("начальное число от 0: ");
            int start = int.Parse(Console.ReadLine());
            Console.Write("начальное число до 50 : ");
            int end = int.Parse(Console.ReadLine());
            Console.Write("количество потоков: ");
            int threadс = int.Parse(Console.ReadLine());

            Thread thread = new Thread(() =>
            {
                for (int i = start; i <= end; i++)
                {
                    Console.WriteLine($"Поток: {Thread.CurrentThread.ManagedThreadId}, число: {i}");
                }
            });

            thread.Start();
        }
    }
}
