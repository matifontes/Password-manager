using System.Collections.Generic;

namespace PasswordManager
{
    public class Profile
    {
        public string password {get; private set;}
        private CategoryRepository categories;
        private PasswordRepository passwords;
        private CreditCardRepository creditCards;

        public Profile(string password) {
            this.password = password;
            categories = new CategoryRepository();
            passwords = new PasswordRepository();
            creditCards = new CreditCardRepository();
        }

        public bool ValidateSystemPassword(string password) 
        {
            return password.Equals(this.password);
        }

        public void ChangePassword(string actualPassword, string newPassword)
        {
            if (ValidateSystemPassword(actualPassword))
            {
                this.password = newPassword;
            }
        }
    }
}