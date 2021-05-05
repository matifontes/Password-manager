using System.Collections.Generic;

namespace PasswordManager
{
    public class Profile
    {
        public string SystemPassword {get; private set;}
        private CategoryRepository categories;
        private PasswordRepository passwords;
        private List<CreditCard> cards;

        public Profile(string password) {
            this.SystemPassword = password;
            categories = new CategoryRepository();
            passwords = new PasswordRepository();
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

        public void AddCreditCard(CreditCard card)
        {
            this.cards.Add(card);
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