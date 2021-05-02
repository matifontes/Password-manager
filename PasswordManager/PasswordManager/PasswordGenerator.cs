using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
    public static class PasswordGenerator
    {

        public static string GeneratePassword(GeneratePasswordSettings settings)
        {
            char[] password = new char[settings.PasswordLength];
            int characterSetLength = settings.CharacterSet.Length;

            for(int charPosition = 0; charPosition<settings.PasswordLength; charPosition++)
            {
                password[charPosition] = 'a';
            }
            return string.Join(null, password);
        }

        public static bool PasswordIsValid(GeneratePasswordSettings settings, string password)
        {
            const string LOWERCASE = @"[a-z]";
            const string UPPERCASE = @"[A-Z]";
            const string NUMERIC = @"[\d]";
            const string SPECIAL = @"([!#$%&.*@\\])+";

            bool lowerCaseIsValid = !settings.IncludeLowerCase || (settings.IncludeLowerCase && System.Text.RegularExpressions.Regex.IsMatch(password, LOWERCASE));
            bool upperCaseIsValid = !settings.IncludeUpperCase|| (settings.IncludeUpperCase && System.Text.RegularExpressions.Regex.IsMatch(password, UPPERCASE));
            bool numericIsValid = !settings.IncludeNumbers || (settings.IncludeNumbers && System.Text.RegularExpressions.Regex.IsMatch(password, NUMERIC));
            bool specialIsValid = !settings.IncludeSpecialCharacters || (settings.IncludeSpecialCharacters && System.Text.RegularExpressions.Regex.IsMatch(password, SPECIAL));

            return (lowerCaseIsValid && upperCaseIsValid && numericIsValid && specialIsValid);
        }
    }
}
