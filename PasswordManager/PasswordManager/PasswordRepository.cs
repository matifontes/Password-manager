using System.Collections.Generic;

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
            this.passwords.Add(password);
        }

        public void RemovePassword(Password password) 
        {
            this.passwords.Remove(password);
        }

        public int Count() {
            return this.passwords.Count;
        }
    }
}