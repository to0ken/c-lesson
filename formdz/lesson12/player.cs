using System;
using System.Threading;

namespace Casino
{
    public class Player
    {
        public int Id { get; }
        public int StartMoney { get; }
        public int CurrentMoney { get; private set; }
        

        private readonly Casino _casino;

        public Player(int id, int startMoney, Casino casino)
        {
            Id = id;
            StartMoney = startMoney;
            CurrentMoney = startMoney;
            _casino = casino;
        }

        public void Play()
        {
            _casino.Log($"Игрок {Id} сел за стол. Баланс: {CurrentMoney}$");

            while (CurrentMoney > 0)
            {

                _casino.TableSemaphore.Wait();
                try
                {

                    int bet = _casino.GetRandomBet(CurrentMoney);
                    int number = _casino.GetRandomNumber();

                    _casino.Log($"Игрок {Id} ставит {bet}$ на число {number}");

   
                    Thread.Sleep(_casino.GetRandomDelay());


                    int rouletteResult = _casino.SpinRoulette();


  
                    if (rouletteResult == number)
                    {

                        CurrentMoney += bet;

                    }
                    else
                    {
                        CurrentMoney -= bet;

                    }
                }
                finally
                {

                    _casino.TableSemaphore.Release();
                }

                Thread.Sleep(300);
            }


            _casino.RegisterResult(this);
        }
    }
}
