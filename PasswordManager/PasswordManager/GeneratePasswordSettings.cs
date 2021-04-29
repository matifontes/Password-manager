using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
    public class GeneratePasswordSettings
    {
        public int PasswordLength { get; set; }
        public bool IncludeLowerCase { get; set; }
        public bool IncludeUpperCase { get; set; }
        public bool IncludeNumbers { get; set; }
        public bool IncludeSpecialCharacters { get; set; }
        
        public GeneratePasswordSettings(int passLength, bool includeLowerCase, bool includeUpperCase, bool includeNumbers, bool includeSpecialCharacters)
        {
            this.PasswordLength = passLength;
            this.IncludeLowerCase = includeLowerCase;
            this.IncludeUpperCase = includeUpperCase;
            this.IncludeNumbers = includeNumbers;
            this.IncludeSpecialCharacters = includeSpecialCharacters;
        }
    }
}
