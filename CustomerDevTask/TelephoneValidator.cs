using System.Text.RegularExpressions;

namespace CustomerDevTask.Web
{
    public static class TelephoneValidator
    {
        public static bool Validate(string number)
        {
            if(string.IsNullOrWhiteSpace(number))
            {
                return false;
            }

            var regex = new Regex("^[0-9]+$");
            return regex.IsMatch(number);
        }
    }
}
