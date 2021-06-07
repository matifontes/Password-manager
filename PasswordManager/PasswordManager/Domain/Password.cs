using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManager.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace PasswordManager
{
    public class Password
    {
        const string LOWERCASE_CHARACTERS = @"[a-z]";
        const string UPPERCASE_CHARACTERS = @"[A-Z]";
        const string NUMERIC_CHARACTERS = @"[\d]";
        const string SPECIAL_CHARACTERS = @"([!#$%&.*@\\,:;\[\])(}{^\|¿\?=~< >¡¨´-])+";
        const string RED_STRENGTH = "Red";
        const string ORANGE_STRENGTH = "Orange";
        const string YELLOW_STRENGTH = "Yellow";
        const string LIGHTGREEN_STRENGTH = "LightGreen";
        const string DARKGREEN_STRENGTH = "DarkGreen";
        const string INVALID_PASSWORD_LENGTH = "Contraseña Invalida, debe tener entre 5 a 25 caracteres";
        const string EMPTY_PASSWORD = "Contraseña Invalida, no puede ser vacia";
        const string INVALID_USER_LENGTH = "Largo de usuario incorrecto";
        const string INVALID_SITE_LENGTH = "Largo de sitio incorrecto";
        const string INVALID_NOTE_LENGTH = "Largo de nota incorrecto";


        private string _user;
        private string _pass;
        private string _site;
        private string _note;

        public int PasswordId { get; set; }
        public Category Category { get; set; }
        public string Pass 
        {
            get { return _pass; }
            set => SetPassword(value);
        }

        public Profile Profile { get; set; }

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
        public Password(Category category, string password, string site, string user, string note, Profile profile)
        {
            this.Category = category;
            this.Pass = password;
            this.Profile = profile;
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
                throw new InvalidPasswordException(INVALID_PASSWORD_LENGTH);
            }
            else if (!IsValidPassword(value))
            {
                throw new InvalidPasswordException(EMPTY_PASSWORD);
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
                throw new InvalidPasswordUserException(INVALID_USER_LENGTH);
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
                throw new InvalidPasswordSiteException(INVALID_SITE_LENGTH);
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
                throw new InvalidPasswordNoteException(INVALID_NOTE_LENGTH);
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

        private bool IsValidPassword(string password)
        {
            string emptyPassword = "";
            for(int i = 0; i < password.Length; i++)
            {
                emptyPassword += " ";
            }
            return emptyPassword != password;
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
                strength = RED_STRENGTH;
            }

            if (PasswordIsOrange(password))
            {
                strength = ORANGE_STRENGTH;
            }

            if (PasswordIsYellow(password))
            {
                strength = YELLOW_STRENGTH;
            }

            if (PasswordIsLightGreen(password))
            {
                strength = LIGHTGREEN_STRENGTH;
            }

            if (PasswordIsDarkGreen(password))
            {
                strength = DARKGREEN_STRENGTH;
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
            return (password.Length > 14 && !PasswordIncludeLowerCase(password)) || (password.Length > 14 && !PasswordIncludeUpperCase(password));
        }

        private bool PasswordIsLightGreen(string password)
        {
            bool onlySpecialChar = (PasswordIncludeSpecialCharacters(password) && !PasswordIncludeNumbers(password));
            bool onlyNumber = (!PasswordIncludeSpecialCharacters(password) && PasswordIncludeNumbers(password));
            bool isLargerThan14AndHasMayusAndMinus = (password.Length > 14 && (PasswordIncludeLowerCase(password) && PasswordIncludeUpperCase(password)));
            return isLargerThan14AndHasMayusAndMinus || (isLargerThan14AndHasMayusAndMinus && (onlySpecialChar || onlyNumber));
        }

        private bool PasswordIsDarkGreen(string password)
        {
            return password.Length > 14 &&
                PasswordIncludeLowerCase(password) &&
                PasswordIncludeUpperCase(password) &&
                PasswordIncludeNumbers(password) &&
                PasswordIncludeSpecialCharacters(password);
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
