
using System.Diagnostics;
using System.Linq.Expressions;


using System;
using System.Linq;

//1.Сделать проверку пороля. Должны быть 5 символов, 3 числа, 1 спец символ. При не выполнение условий, ввод пороля должен вписываться заново пока не подойдет.
class Program
{
    static void Main()
    {
        
        Console.WriteLine(" введите пароль где - есть 5 символов, 3 цифры и !");
        

        while (true)
        {
            Console.Write("Введите пароль: ");
            string password_user = Console.ReadLine();

            if (IsValid(password_user))
            {
                Console.WriteLine("Пароль принят");
                break;
            }
            Console.WriteLine("Не подходит\n");
        }
    }

    static bool IsValid(string password_user)
    {
        
        if (password_user == null || password_user.Length < 5)
        {
            Console.WriteLine("Минимум 5 символов");
            return false;
        }

        
        int digits = password_user.Count(char.IsDigit);
        if (digits < 3)
        {
            Console.WriteLine($" нудно 3 цифры");
            return false;
        }

        
        if (!password_user.Contains('!'))
        {
            Console.WriteLine("в пароле должен быть !");
            return false;
        }

        return true;
    }
}
