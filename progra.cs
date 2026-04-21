using System;

namespace Consolec
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string srt = "KOS123!";
            string symbol = "!";
            // ToUpper - текст большой
            // replise - замена значений
            if (int.TryParse(srt, out int result))
            {
                Console.WriteLine("+ point {reult}");
            }
            else
            {
                Console.WriteLine("no number");
            }
            if (srt.Contains(symbol))
            {
                Console.WriteLine("+ point good there is a symbol");
            }
            else
            {
                Console.WriteLine("no symbol");
            }
                
            }
        }
    }
 


