using System.Collections.Generic;
using PasswordManager.Repositories;

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

        public bool ContainsPassword(Password password) 
        {
            return this.passwords.ContainsPassword(password);
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

        public List<Password> ListPasswordsByStrength(string strength) 
        {
            List<Password> passwords = this.passwords.ListPasswordsByStrength(strength);
            this.passwords.SortListByCategoryName(passwords);
            return passwords;
        }

        public List<Password> ListPasswordsMatching(List<Password> pass)
        {
            List<Password> listRet = this.passwords.GetPasswordMatching(pass);
            this.passwords.SortListByCategoryName(pass);
            return listRet;
        }

        public bool ExistPasswordWithSamePassAndUser(Password pass)
        {
            return this.passwords.ExistPasswordWithSamePassAndUser(pass);
        }

    }
}