using System.Text.RegularExpressions;

namespace ChainOfResponsibility.Services.Validator
{
    public class Validator
    {
        public static bool Email(string email)
        {
            string patron = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, patron);
        }
    }
}
