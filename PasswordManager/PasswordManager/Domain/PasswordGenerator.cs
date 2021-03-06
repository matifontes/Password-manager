using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PasswordManager
{
    public static class PasswordGenerator
    {

        public static string GeneratePassword(PasswordSettings settings)
        {
            char[] pass = new char[settings.PasswordLength];
            int characterSetLength = settings.CharacterSet.Length;
            int charSetOptionsLength = settings.CharSetOptions.Length;
            string password = "";
            int indexOptions = 0;
            System.Random random = new System.Random();

            for (int charPosition = 0; charPosition < settings.PasswordLength; charPosition++)
            {
                if (PickOfCharSetOptions(indexOptions, settings))
                {
                    pass[charPosition] = settings.CharSetOptions[indexOptions][random.Next(settings.CharSetOptions[indexOptions].Length - 1)];
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

        public static bool PickOfCharSetOptions(int indexOptions, PasswordSettings settings)
        {
            bool ret = CheckRange(indexOptions, settings) && !IsEmptyCharSetOptionOnPos(indexOptions, settings);
            return ret;
        }

        public static bool CheckRange(int indexOptions, PasswordSettings settings)
        {
            return indexOptions < settings.CharSetOptions.Length;
        }

        public static bool IsEmptyCharSetOptionOnPos(int indexOptions, PasswordSettings settings)
        {
            return settings.CharSetOptions[indexOptions].Length == 0;
        }

        public static bool PasswordIsValid(PasswordSettings settings, string password)
        {
            bool isValid = true;
            isValid = isValid && ValidateLowerCase(settings, password);
            isValid = isValid && ValidateUpperCase(settings, password);
            isValid = isValid && ValidateNumbers(settings, password);
            isValid = isValid && ValidateSpecialCharacters(settings, password);
            return isValid;
        }

        private static bool ValidateLowerCase(PasswordSettings settings, string password)
        {
            const string LOWERCASE = @"[a-z]";
            bool isValid = !settings.IncludeLowerCase || (settings.IncludeLowerCase && System.Text.RegularExpressions.Regex.IsMatch(password, LOWERCASE));
            return isValid;
        }

        private static bool ValidateUpperCase(PasswordSettings settings, string password)
        {
            const string UPPERCASE = @"[A-Z]";
            bool isValid = !settings.IncludeUpperCase || (settings.IncludeUpperCase && System.Text.RegularExpressions.Regex.IsMatch(password, UPPERCASE));
            return isValid;
        }

        private static bool ValidateNumbers(PasswordSettings settings, string password)
        {
            const string NUMERIC = @"[\d]";
            bool isValid = !settings.IncludeNumbers || (settings.IncludeNumbers && System.Text.RegularExpressions.Regex.IsMatch(password, NUMERIC));
            return isValid;
        }

        private static bool ValidateSpecialCharacters(PasswordSettings settings, string password)
        {
            const string SPECIAL = @"([!#$%&.*@\\,:;\[\])(}{^\|¿\?=~< >¡¨´-])+";
            bool isValid = !settings.IncludeSpecialCharacters || (settings.IncludeSpecialCharacters && Regex.IsMatch(password, SPECIAL));
            return isValid;
        }
    }
}
