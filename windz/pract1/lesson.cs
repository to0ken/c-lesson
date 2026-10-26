
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ConsoleApp1
{
    internal class Program
    {
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "MessageBoxW")]
        public static extern int MessageBox
            (
            IntPtr name,
            string dwMessage,
            string zagaloweok,
            uint uType
            );

        static void Main(string[] args)
        {
            int result = MessageBox(IntPtr.Zero, "hello word", "соо консоли", 0);
            Console.WriteLine(result);


        }
    }
}

