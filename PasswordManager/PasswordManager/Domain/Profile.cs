using System.Collections.Generic;
using PasswordManager.Exceptions;
using PasswordManager.Repositories;

namespace PasswordManager
{
    public class Profile
    {
        const string INVALID_PASSWORD_LENGTH = "Contraseña Invalida, debe tener entre 5 a 25 caracteres";
        const string EMPTY_PASSWORD = "Contraseña Invalida, no puede ser vacia";

        private string _password;

        public int ProfileId { get; set; }
        public string password 
        {
            get { return this._password; }
            set => SetPassword(value);
        }
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
                const string FAIL_TO_VALIDATE_PASSWORD = "Error al validar la contraseña actual";
                throw new FailToValidatePasswordException(FAIL_TO_VALIDATE_PASSWORD);
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

        private void SetPassword(string password) 
        {
            if (!IsValidPassword(password)) 
            {
                
                throw new InvalidPasswordException(EMPTY_PASSWORD);
            }
            else if (!IsValidLength(password)) 
            {
                throw new InvalidPasswordException(INVALID_PASSWORD_LENGTH);
            }
            else
            {
                this._password = password;
            }
        }

        private bool IsValidPassword(string password) 
        {
            string emptyPassword = "";
            for(int i = 0; i < password.Length; i++)
            {
                emptyPassword += " ";
            }
            return password != emptyPassword;
        }

        private bool IsValidLength(string password) 
        {
            return password.Length >= 5 && password.Length <= 25;
        }
    }
}