using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PasswordManager
{
    public class GeneratePasswordSettings
    {
        const string LOWERCASE_CHARACTERS = "abcdefghijklmnopqrstuvwxyz";
        const string UPPERCASE_CHARACTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string NUMERIC_CHARACTERS = "0123456789";
        const string SPECIAL_CHARACTERS = @"!#$%&.*@\";
        public int PasswordLength { get; set; }
        public bool IncludeLowerCase { get; set; }
        public bool IncludeUpperCase { get; set; }
        public bool IncludeNumbers { get; set; }
        public bool IncludeSpecialCharacters { get; set; }
        public string CharacterSet { get; set; }
        public string [] CharSetOptions { get; set; }
        
        public GeneratePasswordSettings(int passLength, bool includeLowerCase, bool includeUpperCase, bool includeNumbers, bool includeSpecialCharacters)
        {
            this.PasswordLength = passLength;
            this.IncludeLowerCase = includeLowerCase;
            this.IncludeUpperCase = includeUpperCase;
            this.IncludeNumbers = includeNumbers;
            this.IncludeSpecialCharacters = includeSpecialCharacters;
            this.CharSetOptions = InitializeCharSetOptionsWithEmptyString();
            StringBuilder characterSet = new StringBuilder();

            if (includeLowerCase)
            {
                characterSet.Append(LOWERCASE_CHARACTERS);
                CharSetOptions[0] = LOWERCASE_CHARACTERS;
            }

            if (includeUpperCase)
            {
                characterSet.Append(UPPERCASE_CHARACTERS);
                CharSetOptions[1] = UPPERCASE_CHARACTERS;
            }

            if (includeNumbers)
            {
                characterSet.Append(NUMERIC_CHARACTERS);
                CharSetOptions[2] = NUMERIC_CHARACTERS;
            }

            if (includeSpecialCharacters)
            {
                
                characterSet.Append(SPECIAL_CHARACTERS);
                CharSetOptions[3] = SPECIAL_CHARACTERS; 
            }

            this.CharacterSet = characterSet.ToString();
        }

        public string[] InitializeCharSetOptionsWithEmptyString()
        {
            this.CharSetOptions = CharSetOptions = new string[4];
            for (int i = 0; i < CharSetOptions.Length; i++)
            {
                this.CharSetOptions[i] = "";
            }
            return this.CharSetOptions;
        }

    }
}
