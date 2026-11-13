using System;
using System.Linq;

public static class TextHelper
{
    public static bool IsPalindrome(string s)
    {
        string clean = new string(s.Where(char.IsLetterOrDigit).ToArray()).ToLower();
        return clean.SequenceEqual(clean.Reverse());
    }
    public static int CountSentences(string s) => s.Split('.', '!', '?').Count(x => x.Trim().Length > 0);
    public static string Reverse(string s) => new string(s.Reverse().ToArray());
}
