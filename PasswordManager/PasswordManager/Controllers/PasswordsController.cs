using System.Collections.Generic;

namespace PasswordManager.Controllers
{
    public class PasswordsController
    {
        private PasswordRepository passwords;

        public PasswordsController(PasswordRepository passwords)
        {
            this.passwords = passwords;
        }

        public void AddPassword(Password password) 
        {
            this.passwords.AddPassword(password);
        }

        public bool Contains(Password password) 
        {
            return this.passwords.Contains(password);
        }

        public void RemovePassword(Password password) 
        {
            this.passwords.RemovePassword(password);
        }

        public bool IsEmpty() 
        {
            return this.passwords.IsEmpty();
        }

        public int Count() 
        {
            return this.passwords.Count();
        }

        public List<Password> ListPasswords() 
        {
            return this.passwords.ListPasswords();
        }

        public List<Password> ListRedPasswords()
        {
            List<Password> listRedPasswords = this.passwords.ListRedPasswords();
            this.passwords.SortListByCategoryName(listRedPasswords);
            return listRedPasswords;
        }

        public List<Password> ListOrangePasswords()
        {
            List<Password> listOrangePasswords = this.passwords.ListOrangePasswords();
            this.passwords.SortListByCategoryName(listOrangePasswords);
            return listOrangePasswords;
        }
        public List<Password> ListYellowPasswords()
        {
            List<Password> listYellowPasswords = this.passwords.ListYellowPasswords();
            this.passwords.SortListByCategoryName(listYellowPasswords);
            return listYellowPasswords;
        }
        public List<Password> ListLightGreenPasswords()
        {
            List<Password> listLightGreenPasswords = this.passwords.ListLGreenPasswords();
            this.passwords.SortListByCategoryName(listLightGreenPasswords);
            return listLightGreenPasswords;
        }

        public List<Password> ListDarkGreenPasswords()
        {
            List<Password> listDarkGreenPasswords = this.passwords.ListDGreenPasswords();
            this.passwords.SortListByCategoryName(listDarkGreenPasswords);
            return listDarkGreenPasswords;
        }

    }
}