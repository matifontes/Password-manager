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
            char[] pass = new char[settings.PasswordLength];
            int characterSetLength = settings.CharacterSet.Length;
            string password = "";
            int attemps = 0;
            System.Random random = new System.Random();

            while (!PasswordIsValid(settings, password) && attemps < 1000)
            {
                for (int charPosition = 0; charPosition < settings.PasswordLength; charPosition++)
                {
                    pass[charPosition] = settings.CharacterSet[random.Next(characterSetLength -1)];
                }
                attemps++;
                password = string.Join(null, pass);
            }
            return password;
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
