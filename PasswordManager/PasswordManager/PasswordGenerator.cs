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
            int charSetOptionsLength = settings.CharSetOptions.Length;
            string password = "";
            int indexOptions = 0;
            System.Random random = new System.Random();

            for (int charPosition = 0; charPosition < settings.PasswordLength; charPosition++)
            {
                if (indexOptions < charSetOptionsLength && settings.CharSetOptions[indexOptions].Length > 0)
                {
                    pass[charPosition] = settings.CharSetOptions[indexOptions][random.Next(charSetOptionsLength - 1)];
                }
                else
                {
                    pass[charPosition] = settings.CharacterSet[random.Next(characterSetLength - 1)];
                }
                indexOptions++;
            }
            password = string.Join(null, pass);
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
