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
    }
}
