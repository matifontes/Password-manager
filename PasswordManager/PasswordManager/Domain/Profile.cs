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

        public bool ValidatePassword(string password) 
        {
            return password.Equals(this.password);
        }

        public void ChangePassword(string actualPassword, string newPassword)
        {
            if (ValidatePassword(actualPassword))
            {
                this.password = newPassword;
            }
            else 
            {
                throw new FailToValidatePasswordException("Error al validar la contraseña actual");
            }
        }

        public CategoryRepository GetCategoryRepository() 
        {
            return this.categories;
        }

        public PasswordRepository GetPasswordRepository() 
        {
            return this.passwords;
        }

        public CreditCardRepository GetCreditCardRepository() 
        {
            return this.creditCards;
        }
    }
}