using System.Text.RegularExpressions;
using System.Linq;

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

            number = string.Concat(number.Where(x => !char.IsWhiteSpace(x)));
            var regex = new Regex("^[0-9]+$");

            return regex.IsMatch(number);
        }
    }
}
