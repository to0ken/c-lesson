using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace ConsoleApp1
{

    class Program
    {
    [DllImport("kernel32.dll")]
    static extern bool Beep(uint frequency, uint duration);

    [DllImport("user32.dll")]
    static extern bool MessageBeep(uint type);

    static void Main()
    {
        Console.WriteLine("Начало воспроизведения сигналов");

        for (int i = 0; i < 5; i++)
        {
            Beep(400, 500);
            Thread.Sleep(1000);
            Beep(1000, 300);
            Thread.Sleep(1000);
            MessageBeep(0xFFFFFFFF);
        }
    }
}
