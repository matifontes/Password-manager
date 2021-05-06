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
        private string _user;
        private string _pass;
        private string _site;
        private string _note;
        public Category Category { get; set; }
        public string Pass 
        {
            get { return _pass; }
            set => setPassword(value);
        }

        public string Site {
            get { return _site; }
            set => setSite(value);
        }

        public string User
        {
            get { return _user; }
            private set => setUser(value); 
        }
        public string Note 
        { 
            get { return _note; }
            private set => setNote(value);
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

    }
}
