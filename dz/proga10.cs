using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


/*Делегат
1. Таймер: метод DoAfter(Action action, int seconds) — выполняет действие через N секунд
События
2. Будильник: класс AlarmClock с событием AlarmRang. Установка времени, проверка каждую секунду.*/



class Program
{
    static void Main()
    {
        DoAfter(() => Console.WriteLine("Таймер сработал"), 2);

        var alarm = new AlarmClock(DateTime.Now.AddSeconds(3));
        alarm.AlarmRang += () => Console.WriteLine("будтльник");
        alarm.Start();
    }


    static void DoAfter(Action action, int seconds)
    {
        Thread.Sleep(seconds * 1000);
        action();
    }
}

class AlarmClock
{
    public event Action AlarmRang;
    private readonly DateTime _target;

    public AlarmClock(DateTime time) => _target = time;

    public void Start()
    {
        while (DateTime.Now < _target) Thread.Sleep(1000);
        AlarmRang?.Invoke(); 
    }
}
