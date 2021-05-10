using System.Collections.Generic;

namespace PasswordManager
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
    }
}