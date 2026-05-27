using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


public class HistogramArray
{
    private double[] data;
    private int intervalCount;


    private double min;
    private double max;
    private double width; 


    public HistogramArray(double[] data, int intervals)
    {
        this.data = data;
        this.intervalCount = intervals;

        // Находим границы массива
        this.min = data.Min();
        this.max = data.Max();


        this.width = (max == min) ? 0 : (max - min) / intervals;
    }


    public int GetInterval(double value)
    {

        if (value < min || value > max) return -1;
        int index = (int)((value - min) / width);
        if (index == intervalCount) index--;

        return index;
    }


    public double GetPercentile(double percentile)
    {
        if (percentile < 0 || percentile > 100)
            throw new ArgumentException("Процентиль от 0 до 100");

        var sortedData = data.OrderBy(x => x).ToArray();
        int rank = (int)Math.Round((percentile / 100.0) * (sortedData.Length - 1));
        return sortedData[rank];
    }
}

class Program
{
    static void Main()
    {
        double[] numbers = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };


        var hist = new HistogramArray(numbers, 5);

        Console.WriteLine($"Значение  {hist.GetInterval(25)}"); 
        Console.WriteLine($"Значение  {hist.GetInterval(55)}"); 


        Console.WriteLine($"50% {hist.GetPercentile(50)}"); 
        Console.WriteLine($"90%: {hist.GetPercentile(90)}");           
    }
}

