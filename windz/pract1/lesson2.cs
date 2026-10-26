using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Filename
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
            int playAgain = 6;
            while (playAgain == 6)
            {
                int min = 1;
                int max = 10;
                int attempts = 0;
                bool guessed = false;
                

                MessageBox(IntPtr.Zero, "Загадайте число от 1 до 10.Я буду его угадывать!", "Старт", 0);

                while (min <= max && !guessed)
                {
                    int guess = min + (max - min) / 2; 
                    attempts++;

                    string prompt = $"Моё число: {guess}" +
                                    "[Да]     = Угадал! (=)" +
                                    "[Нет]    = Моё число БОЛЬШЕ (>)" +
                                    "[Отмена] = Моё число МЕНЬШЕ (<)";

                    
                    int result = MessageBox(IntPtr.Zero, prompt, "Проверка", 35);

                    if (result == 6)
                    {
                        MessageBox(IntPtr.Zero, $" {guess} за {attempts}", "Победа", 0);
                        guessed = true;
                    }
                    else if (result == 7) 
                    {
                        min = guess + 1;
                    }
                    else if (result == 2) 
                    {
                        max = guess - 1;
                    }
                    else 
                    {
                        break;
                    }
                }


        }
    }
}
