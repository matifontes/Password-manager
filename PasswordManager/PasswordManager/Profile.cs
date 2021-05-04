using System.Collections.Generic;

namespace PasswordManager
{
    public class Profile
    {
        public string SystemPassword {get; private set;}
        private List<Category> categories;
        private List<Password> passwords;
        private List<CreditCard> cards;

        public Profile(string password) {
            this.SystemPassword = password;
            categories = new List<Category>();
            passwords = new List<Password>();
            cards = new List<CreditCard>();
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

        public void AddCategory(Category category) 
        {
            this.categories.Add(category);
        }

        public void AddPassword(Password pass)
        {
            this.passwords.Add(pass);
        }
        public void AddCreditCard(CreditCard card)
        {
            this.cards.Add(card);
        }

        public bool CategoryExists(Category category) 
        {
            return this.categories.Contains(category);
        }

        public bool PasswordExists(string pass)
        {
            foreach (Password passAux in passwords)
            {
                if (passAux.Pass.Equals(pass))
                {
                    return true;
                }
            }
            return false;
        }

        public bool CreditCardExists(long cardNumber)
        {
            foreach (CreditCard cardAux in cards)
            {
                if (cardAux.Number.Equals(cardNumber))
                {
                    return true;
                }
            }
            return false;
        }
    }
}