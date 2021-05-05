using System.Collections.Generic;

namespace PasswordManager
{
    public class Profile
    {
        public string SystemPassword {get; private set;}
        private CategoryRepository categories;
        private PasswordRepository passwords;
        private CreditCardRepository creditCards;

        public Profile(string password) {
            this.SystemPassword = password;
            categories = new CategoryRepository();
            passwords = new PasswordRepository();
            creditCards = new CreditCardRepository();
        }

        public bool ValidateSystemPassword(string password) 
        {
            return password.Equals(SystemPassword);
        }

        public void ChangePassword(string actualPassword, string newPassword)
        {
            if (ValidateSystemPassword(actualPassword))
            {
                this.SystemPassword = newPassword;
            }
        }
    }
}