using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Квадрат (5): " + Geometry.Square(5));
        Console.WriteLine("Прямоугольник (4, 5): " + Geometry.Rectangle(4, 5));
        Console.WriteLine("Треугольник (4, 5): " + Geometry.Triangle(4, 5));
        Console.ReadLine();
    }
}
