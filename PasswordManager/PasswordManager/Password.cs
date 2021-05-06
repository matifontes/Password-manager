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
        const string LOWERCASE_CHARACTERS = "abcdefghijklmnopqrstuvwxyz";
        const string UPPERCASE_CHARACTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string NUMERIC_CHARACTERS = "0123456789";
        const string SPECIAL_CHARACTERS = @"!#$%&.*@\";
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
            private set => SetUser(value); 
        }
        public string Note 
        { 
            get { return _note; }
            private set => SetNote(value);
        }
        
        public string Strength { get; set; }
        public DateTime LastModificationDate { get; set; }

        public Password(Category category, string password, string site, string user, string note)
        {
            this.Category = category;
            this.Pass = password;
            this.Site = site;
            this.User = user;
            this.Note = note;
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
                this.LastModificationDate = DateTime.Today;
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
            }
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
            bool ret = false;
            if (password.Length > 14)
            {
                if(!PasswordIncludeSpecialCharacters(password) && !PasswordIncludeNumbers(password))
                {
                    ret = (PasswordIncludeLowerCase(password) && !PasswordIncludeUpperCase(password));
                    ret = ret || (!PasswordIncludeLowerCase(password) && PasswordIncludeUpperCase(password));
                }
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
