using System;
using System.Numerics;

public class Program
{
    public static string LongestCommonPrefix(string[] strs)
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


public static void Main()
    {
        Console.WriteLine("conclusion");

        Console.WriteLine(string.Format("Otvet = {0}",
            LongestCommonPrefix(new string[] { "momis", "momus", "momps" }))); // "mom"

        Console.WriteLine(string.Format("Otvet = {0}",
            LongestCommonPrefix(new string[] { "six", "stop", "true" }))); // ""

        Console.WriteLine(FactNaive(11));
    }
   

}
