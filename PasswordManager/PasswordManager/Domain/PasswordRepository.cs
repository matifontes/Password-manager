using System.Collections.Generic;
using System.Linq;
using PasswordManager.Exceptions;

namespace PasswordManager
{
    public class PasswordRepository
    {

        private List<Password> passwords;
        public PasswordRepository() 
        {
            passwords = new List<Password>();        
        }

        public void AddPassword(Password password) 
        {
            if (this.ContainsPassword(password))
            {
                const string PASSWORD_ALREADY_EXISTS_MSG = "El conjunto Usuario Sitio de la contraseña ya existe";
                throw new PasswordAlreadyExistsException(PASSWORD_ALREADY_EXISTS_MSG);
            }
            else 
            {
                this.passwords.Add(password);
            }
        }

        public bool ContainsPassword(Password password) 
        {
            bool notExists = false;
            foreach (Password pass in this.passwords) 
            {
                if (pass.IsEqual(password)) 
                {
                    return true;
                }
            }
            return notExists;
        }

        public void RemovePassword(Password password) 
        {
            this.passwords.Remove(password);
        }

        public bool IsEmpty() 
        {
            return this.Count() == 0;
        }

        public bool IsEmptyList(List<Password> listPass)
        {
            return listPass.Count == 0;
        }

        public int Count() {
            return this.passwords.Count;
        }

        public List<Password> ListPasswords() 
        {
            return this.passwords.OrderBy(password => password.Category.Name).ToList();
        }

        public List<Password> ListPasswordsByStrength(string strength) 
        {
            List<Password> passwords = new List<Password>();
            foreach (Password pass in this.passwords)
            {
                if (pass.Strength == strength)
                {
                    passwords.Add(pass);
                }
            }
            return SortListByCategoryName(passwords);
        }

        public List<Password> SortListByCategoryName(List<Password> pass)
        {
            return pass.OrderBy(password => password.Category.ToString()).ToList();
        }

        public List<Password> GetPasswordMatching(List<Password> passList)
        {
            List<Password> ret = new List<Password>();
            foreach (Password pass in this.passwords)
            {
                foreach (Password pass2 in passList)
                {
                    if (pass.Pass.Equals(pass2.Pass) && !ret.Contains(pass))
                    {
                        ret.Add(pass);
                    }
                }
            }
            return ret;
        }
    }
}