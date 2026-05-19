
using System.Diagnostics;
using System.Linq.Expressions;

namespace pointless
{
    struct Pointvector
    {
        public int X; public int Y;
        public Pointvector(int x, int y)
        {
            X = x;
            Y = y;
        }
        public double Length() => Math.Sqrt(X * X + Y * Y);
        public double AddVector() => X + Y;
        public double NormalX() => X / Math.Sqrt(X * X + Y * Y);
        public double NormalY() => Y / Math.Sqrt(X * X + Y * Y);

    }

    struct Money
    {
        public int Rubl;
        public int Kopeyk;

        public Money(int rubl , int kopeyk)
        {
            Rubl = rubl;
            Kopeyk = kopeyk;
            int transfer = kopeyk * 100 + rubl;
            Rubl = transfer / 100;
            Kopeyk = transfer % 100;
        }

        // перевод в копейку, рубль
        public int inKopecks() => Rubl * 100 + Kopeyk;
        public int inRubl() => Kopeyk * 100 + Rubl;
    }

    class Progg
    {
        static void Main(string[] args)
        {
            
                

                
             Console.WriteLine("Выберите транспорт: 1-машина, 2-велосипед, 3-самолет, 0-Exit");
             string? vehicleChoice = Console.ReadLine();

                   
        }
    }
}
    
    
    

