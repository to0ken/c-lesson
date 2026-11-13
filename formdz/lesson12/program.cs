using System;
using System.Collections.Generic;
using System.Threading;

namespace Casino
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Начало рабочего дня.\n");

            Casino casino = new Casino();
            Random random = new Random();


            int totalPlayers = random.Next(20, 101);


            Queue<Player> playersQueue = new Queue<Player>();
            for (int i = 1; i <= totalPlayers; i++)
            {
                int startMoney = random.Next(500, 2001); 
                playersQueue.Enqueue(new Player(i, startMoney, casino));
            }

            List<Thread> allThreads = new List<Thread>();

            while (playersQueue.Count > 0)
            {

                casino.TableSemaphore.Wait();
                Player player = playersQueue.Dequeue();
                Thread thread = new Thread(player.Play);
                thread.Name = $"Player_{player.Id}";
                allThreads.Add(thread);
                thread.Start();


                casino.TableSemaphore.Release();
            }

            Console.WriteLine("\ Ожидание завершения всех игроков...");
            foreach (Thread thread in allThreads)
            {
                thread.Join();
            }

            Console.WriteLine("\n Рабочий день окончен!\n");
            casino.SaveReport("casino_report.txt");

            Console.ReadKey();
        }
    }
}
