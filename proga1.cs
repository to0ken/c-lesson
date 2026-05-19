using sortprog;
using System.Diagnostics;
using System.Linq.Expressions;


interface Ifigure
{
    string Name { get; }
    double GetArena();
    double GetPerimetr();
}

 public class Сircle : Ifigure
{
    public string Name => "круг";

    double radius;
    double Ifigure.GetArena() => radius;
    double Ifigure.GetPerimetr() => 2* radius* Math.PI;
    
}

public class Square: Ifigure
{
    public string Name => "квадрат";

    double side;
    double Ifigure.GetArena() => side * side;
    double Ifigure.GetPerimetr() => 4 * side;

}

public class Triangle : Ifigure
{
    public string Name => "треугольник";

    double a, b, c;
    double Ifigure.GetArena()
    {
        double square = (a + b + c) / 2;
        return Math.Sqrt(square * (square - a) * (square - b) * (square - c));
    }
    public double GetPerimetr() => a+ b + c;
    
}

namespace programm
{
    interface IVechicle
    {
        string Name { get; }
        void Start();
        void Stop();
        int GetSpeed();
    }

    public class Car: IVechicle
    {
        public string Name => "машина";

        int speed;

        public void Start() 
        { 
            speed = 60;
        }

        public void Stop()
        {
            speed = 0;
        }
        public int GetSpeed() 
        {
            return speed;
        }
    }

    public class Bicycle : IVechicle
    {
        public string Name => "велосипед";

        int speed;

        public void Start()
        {
            speed = 100;
        }

        public void Stop()
        {
            speed = 0;
        }
        public int GetSpeed()
        {
            return speed;
        }
    }

    public class Airoplane : IVechicle
    {
        public string Name => "самолет";

        int speed;

        public void Start()
        {
            speed = 900;
        }

        public void Stop()
        {
            speed = 0;
        }
        public int GetSpeed()
        {
            return speed;
        }
    }

    class Program
    {
        static void Main(string[] args) {
            IVechicle? vehicle = null;

            while (true)
            {
                Console.WriteLine("Выберите транспорт: 1-машина, 2-велосипед, 3-самолет, 0-Exit");
                string? vehicleChoice = Console.ReadLine();

                if (vehicleChoice == "0") break;

                switch (vehicleChoice)
                {
                    case "1":
                        vehicle = new Car();
                        break;
                    case "2":
                        vehicle = new Bicycle();
                        break;

                    case "3":
                        vehicle = new Airoplane();
                        break;

                    default:
                        Console.WriteLine(" нет выбора");
                        continue;
                }

                while (true)
                {
                    Console.WriteLine("Выберите действие: 1-старт, 2-стоп, 3-скорость");
                    string? action = Console.ReadLine();

                    if (action == "0") break;

                    switch (action)
                    {
                        case "1":
                            vehicle.Start();
                            Console.WriteLine("старт ");
                            break;
                        case "2":
                            vehicle.Stop();
                            Console.WriteLine("стоп");
                            break;
                        case "3":
                            Console.WriteLine($"узнать скорость: {vehicle.GetSpeed()}");
                            break;
                        default:
                            Console.WriteLine("неверно");
                            break;
                    }
                }
            }
        }
    }
}


namespace sortprog
{
    interface ISortable
    {
        void Sort(int[] array);
    }

    class BubleSort : ISortable
    {
        void ISortable.Sort(int[] array) {
            
                for (int i = 0; i < array.Length; i++) // Внешний цикл: проходы
                {
                    for (int j = 0; j < array.Length - 1 - i; j++) // Внутренний цикл: сравнение соседних
                    {
                        if (array[j] > array[j + 1])
                        {
                            // Обмен элементами
                            int temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }

                    }
                }
            }
        }
    }

    class SelectionSort : ISortable
{
        void ISortable.Sort(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            
            int minElement = i;

            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[j] < array[minElement]) minElement = j;
                
            }

            if(minElement != i)
            {
                int temp = array[i];
                array[i] = array[minElement];
                array[minElement] = temp;
            }
            //int temp = array[minIndex];
            //array[minIndex] = array[i];
            //array[i] = temp;


        }
    }

    static void Main(string[] args)
    {
        int[] data = { 10, 5, 9, 8, 17 };
        ISortable[] stors = { new SelectionSort(), new SelectionSort() };
        for (int i = 0; i < stors.Length; i++) 
        {
            // копируем массив и вставляем в интерфейс
            int[] copy = (int[])data.Clone();
            stors[i].Sort(copy);
            Console.WriteLine($"{i}");

        }
    }
}
