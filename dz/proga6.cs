
using System.Diagnostics;
using System.Linq.Expressions;

// 1.Создать родительский класс exchange, и дочернии классы валют(usd,rub,eur,uan,peso), в которых находятся вызов родительского метода для инфо о курсе двух валют.
class Money
{
    
    public void ShowRate(string from, string to, decimal rate)
    {
        Console.WriteLine($"1 {from} = {rate} {to}");
    }
}


class USD : Money
{
    public void GetInfo()
    {
        
        base.ShowRate("USD", "RUB", 92.50m);
        base.ShowRate("USD", "EUR", 0.92m);
    }
}

class RUB : Money
{
    public void GetInfo() => base.ShowRate("RUB", "USD", 0.011m);
}

class EUR : Money
{
    public void GetInfo() => base.ShowRate("EUR", "USD", 1.08m);
}

class UAN : Money
{
    public void GetInfo() => base.ShowRate("UAN", "RUB", 12.80m);
}

class Peso : Money
{
    public void GetInfo() => base.ShowRate("Peso", "USD", 0.058m);
}

class Program
{
    static void Main()
    {
        

        new USD().GetInfo();
        new RUB().GetInfo();
        new EUR().GetInfo();
        new UAN().GetInfo();
        new Peso().GetInfo();
    }
}
