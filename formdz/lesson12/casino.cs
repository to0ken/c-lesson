using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Casino
{
    public class Casino
    {

        public SemaphoreSlim TableSemaphore { get; } = new SemaphoreSlim(5, 5);

        private readonly Random _random = new Random();
        private readonly object _randomLock = new object(); 
        private readonly object _consoleLock = new object();
        private readonly object _resultsLock = new object();
        private readonly List<Player> _results = new List<Player>();


        public int GetRandomBet(int currentMoney)
        {
            lock (_randomLock)
            {
                int maxBet = Math.Min(100, currentMoney);
                if (maxBet < 10) maxBet = currentMoney; 
                return _random.Next(10, maxBet + 1);
            }
        }


        public int GetRandomNumber()
        {
            lock (_randomLock)
            {
                return _random.Next(0, 37);
            }
        }


        public int SpinRoulette()
        {
            lock (_randomLock)
            {
                return _random.Next(0, 37);
            }
        }


        public int GetRandomDelay()
        {
            lock (_randomLock)
            {
                return _random.Next(200, 800);
            }
        }


        public void Log(string message)
        {
            lock (_consoleLock)
            {
                Console.WriteLine(message);
            }
        }


        public void RegisterResult(Player player)
        {
            lock (_resultsLock)
            {
                _results.Add(player);
            }
        }


        public void SaveReport(string filePath)
        {
            lock (_resultsLock)
            {

                _results.Sort((a, b) => a.Id.CompareTo(b.Id));

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine($"Всего игроков: {_results.Count}\n");

                    foreach (var player in _results)
                    {
                        writer.WriteLine($"Игрок{player.Id} [{player.StartMoney}$] [{player.CurrentMoney}$]");
                    }
                }
            }
        }
    }
}
