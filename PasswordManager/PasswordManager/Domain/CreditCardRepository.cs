using System.Collections.Generic;
using System.Linq;

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

        public bool IsEmpty() 
        {
            return this.Count() == 0;
        }

        public List<CreditCard> ListCreditCards()
        {
            return this.creditCards.OrderBy(creditCard => creditCard.Category.Name).ToList();
        }
    }
}