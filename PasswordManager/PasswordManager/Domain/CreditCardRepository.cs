using System.Collections.Generic;

namespace PasswordManager
{
    public class CreditCardRepository
    {
        private List<CreditCard> creditCards;
        public CreditCardRepository() 
        {
            creditCards = new List<CreditCard>();
        }

        public void AddCreditCard(CreditCard creaditCard) 
        {
            this.creditCards.Add(creaditCard);
        }

        public void RemoveCreditCard(CreditCard creditCard) 
        {
            this.creditCards.Remove(creditCard);
        }

        public int Count() 
        {
            return this.creditCards.Count;
        }
    }
}