using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    
    internal class find1
    {
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern IntPtr FindWindow(
            string lpClassName,
            string lpWindowName
            );

        static void Main(string[] args)
        {
            IntPtr name = FindWindow("Notepad", null);


            

            if (name != IntPtr.Zero)
            {
                Console.WriteLine(name);
            }
            else
            {
                Console.WriteLine("Окно Блокнота не найдено");
            }


        }

    }
}
