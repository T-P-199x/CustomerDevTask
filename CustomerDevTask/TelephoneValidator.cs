using System.Text.RegularExpressions;

namespace CustomerDevTask.Web
{
    public static class TelephoneValidator
    {
        public static bool Validate(string number)
        {
            var regex = new Regex("^[0-9]+$");
            return regex.IsMatch(number);
        }
    }
}
