using System.Text.RegularExpressions;

namespace Connapp
{
    public static class Progvall
    {

        private static readonly string EmailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        

        private static readonly string PhonePattern = @"^\+?[0-9\s\-\(\)]{10,15}$";

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            return Regex.IsMatch(email, EmailPattern);
        }

        public static bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return false;
            return Regex.IsMatch(phone, PhonePattern);
        }
    }
}
