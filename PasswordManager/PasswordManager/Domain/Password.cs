using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManager.Exceptions;

namespace PasswordManager
{
    public class Password
    {
        const string LOWERCASE_CHARACTERS = @"[a-z]";
        const string UPPERCASE_CHARACTERS = @"[A-Z]";
        const string NUMERIC_CHARACTERS = @"[\d]";
        const string SPECIAL_CHARACTERS = @"([!#$%&.*@\\,:;\[\])(}{^\|¿\?=~< >¡¨´-])+";
        private string _user;
        private string _pass;
        private string _site;
        private string _note;
        public Category Category { get; set; }
        public string Pass 
        {
            get { return _pass; }
            set => SetPassword(value);
        }

        public string Site {
            get { return _site; }
            set => SetSite(value);
        }

        public string User
        {
            get { return _user; }
            set => SetUser(value); 
        }
        public string Note 
        { 
            get { return _note; }
            set => SetNote(value);
        }
        
        public string Strength { get; set; }
        public DateTime LastModificationDate { get; set; }

        public Password(string password)
        {
            Category defaultCategory = new Category("Default");
            this.Category = defaultCategory;
            this.Pass = password;
            this.Site = "www.default.com";
            this.User = "Default";
            this.Note = "Default";
            this.Strength = PasswordStrength(password);
        }

        public Password(Category category, string password, string site, string user, string note)
        {
            this.Category = category;
            this.Pass = password;
            this.Site = site;
            this.User = user;
            this.Note = note;
        }

        public bool IsEqual(Password password) 
        {
            bool equals = false;

            string site = this.Site.ToUpper();
            string user = this.User.ToUpper();

            string passwordSite = password.Site.ToUpper();
            string passwordUser = password.User.ToUpper();

            equals = site == passwordSite;
            equals = equals && user == passwordUser;

            return equals;            
        }

        private void SetPassword(string value)
        {
            if (!IsValidLength(value))
            {
                throw new InvalidPasswordException("Largo de contraseña incorrecto");
            }
            else
            {
                this._pass = value;
                this.LastModificationDate = DateTime.Now;
                this.Strength = PasswordStrength(value);
            }
        }
        private void SetUser(string value)
        {
            if (!IsValidLength(value))
            {
                throw new InvalidPasswordUserException("Largo de usuario incorrecto");
            }
            else
            {
                this._user = value;
                this.LastModificationDate = DateTime.Now;
            }
        }

        private void SetSite(string value)
        {
            if (!IsValidSiteLength(value))
            {
                throw new InvalidPasswordSiteException("Largo de sitio incorrecto");
            }
            else
            {
                this._site = value;
                this.LastModificationDate = DateTime.Now;
            }
        }

        private void SetNote(string value)
        {
            if (!IsValidNoteLength(value))
            {
                throw new InvalidPasswordNoteException("Largo de nota incorrecto");
            }
            else
            {
                this._note = value;
                this.LastModificationDate = DateTime.Now;
            }
        }

        public override string ToString()
        {
            return this.User;
        }

        private bool IsValidLength(string toCheck)
        {
            int amountOfDigits = toCheck.Length;
            return (amountOfDigits >= 5 && amountOfDigits <= 25);
        }

        private bool IsValidSiteLength(string site)
        {
            int amountOfDigits = site.Length;
            return (amountOfDigits >= 3 && amountOfDigits <= 25);
        }

        private bool IsValidNoteLength(string note)
        {
            int amountOfDigits = note.Length;
            return (amountOfDigits <= 250);
        }

        private string PasswordStrength(string password)
        {
            string strength = "";
           
            if (PasswordIsRed(password))
            {
                strength = "Red";
            }

            if (PasswordIsOrange(password))
            {
                strength = "Orange";
            }

            if (PasswordIsYellow(password))
            {
                strength = "Yellow";
            }

            if (PasswordIsLightGreen(password))
            {
                strength = "LightGreen";
            }

            if (PasswordIsDarkGreen(password))
            {
                strength = "DarkGreen";
            }
            return strength;
        }

        private bool PasswordIsRed(string password)
        {
            return password.Length < 8;

        }

        private bool PasswordIsOrange(string password)
        {
            return password.Length >= 8 && password.Length <= 14;
        }

        private bool PasswordIsYellow(string password)
        {
            bool ret = password.Length > 14;
            ret = (ret && !PasswordIncludeLowerCase(password)) || (ret && !PasswordIncludeUpperCase(password));
            return ret;
        }

        private bool PasswordIsLightGreen(string password)
        {
            bool ret = false;
            if (password.Length > 14)
            {
                ret = (PasswordIncludeLowerCase(password) && PasswordIncludeUpperCase(password));
                bool onlySpecialChar = (PasswordIncludeSpecialCharacters(password) && !PasswordIncludeNumbers(password));
                bool onlyNumber =  (!PasswordIncludeSpecialCharacters(password) && PasswordIncludeNumbers(password));
                ret = ret || (ret && (onlySpecialChar || onlyNumber));
            }
            return ret;
        }

        private bool PasswordIsDarkGreen(string password)
        {
            bool ret = false;
            if (password.Length > 14)
            {
                ret = PasswordIncludeLowerCase(password);
                ret = ret && PasswordIncludeUpperCase(password);
                ret = ret && PasswordIncludeNumbers(password);
                ret = ret && PasswordIncludeSpecialCharacters(password);
            }
            return ret;
        }

        private bool PasswordIncludeSpecialCharacters(string password)
        {
           return System.Text.RegularExpressions.Regex.IsMatch(password, SPECIAL_CHARACTERS);
        }
        private bool PasswordIncludeNumbers(string password)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(password, NUMERIC_CHARACTERS);
        }
        private bool PasswordIncludeUpperCase(string password)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(password, UPPERCASE_CHARACTERS);
        }
        private bool PasswordIncludeLowerCase(string password)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(password, LOWERCASE_CHARACTERS);
        }      
    }
}
