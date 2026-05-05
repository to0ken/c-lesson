using System;
using System.Numerics;


 class Program
{
    static string LongestCommonPrefix(string[] strs)
    {
        // количество строк 
        int len = strs.Length;
        if (len == 0) return "";

        string prefix = strs[0];
        for (int i = 1; i < len; i++)
        {
            while (strs[i].IndexOf(prefix) != 0)
            {
                // убираем последний симыол из префикса
                prefix = prefix.Substring(0, prefix.Length - 1);
                if (prefix == "") return "";
            }
        }

        return prefix;
    }


    static BigInteger FactNaive(int n)
    {
        BigInteger r = 1;
        for (int i = 2; i <= n; ++i)
            r *= i;
        return r;
    }

    // ghbybvftn lfyyst b sjpshfoftn
    // -----------------------------------------------------------------
    // Тип BigInteger — это неизменяемый тип,
    // представляющий произвольно большое целое число,
    // значение которого в теории не имеет верхних или нижних границ. 
    // -----------------------------------------------------------------



    // ЗАДАНИЕ 1 ------------ вывод только четных значний в массиве через функцию -----------------
    // void - не требуется return

    static void EvenNumbers(int[] n)
    {
        //int count = 0;
        int[] arr = { 3, 5, 6, 7, 12, 22, 24, 25 };

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] % 2 == 0)
            {
                Console.WriteLine(arr[i]);
                //count++;

            }
        }
        //return count;
    }

    // --------------------------- СОРТИРОВКА МАССИВА ПО КОЛИЧЕСТВУ ДЕЛИТОЕЙ

    static int numbertest(int n)
    {
        if (n == 0) return 0;
        int count = 0;
        for(int i = 1; i <= n; i++)
        {
            if (n % i == 0)
            {
                count++;
            }
        }
        return count;
    }



    static void Main()
    {
        /*Console.WriteLine("conclusion");

        Console.WriteLine(string.Format("Otvet = {0}",
            LongestCommonPrefix(new string[] { "momis", "momus", "momps" }))); // "mom"

        Console.WriteLine(string.Format("Otvet = {0}",
            LongestCommonPrefix(new string[] { "six", "stop", "true" }))); // ""

        Console.WriteLine(FactNaive(11));*/

        //  ЗАДАНИЕ 1 ===========================================================
        int[] marr = { 3, 5, 6, 7, 12, 22, 24, 25 };
        EvenNumbers(marr);
        Console.WriteLine(marr);

        int[] num = { 4, 8, 16 };


        
    }
}
