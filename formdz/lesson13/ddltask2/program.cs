using System;

class Program
{
    static void Main()
    {
        string text = "А роза упала на лапу Азора. Это тест!";
        Console.WriteLine("Палиндром (шалаш): " + TextHelper.IsPalindrome("шалаш"));
        Console.WriteLine("Предложений: " + TextHelper.CountSentences(text));
        Console.WriteLine("Переворот (привет): " + TextHelper.Reverse("привет"));
        Console.ReadLine();
    }
}
