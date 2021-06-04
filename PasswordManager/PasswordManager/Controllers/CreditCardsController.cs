using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Controllers
{
    public class CreditCardsController
    {
        private CreditCardRepository creditCards;

        public CreditCardsController(CreditCardRepository creditCards)
        {
            this.creditCards = creditCards;
        }

        public void AddCreditCard(CreditCard creditCard)
        {
            this.creditCards.AddCreditCard(creditCard);
        }

        public void RemoveCreditCard(CreditCard creditCard)
        {
            this.creditCards.RemoveCreditCard(creditCard);
        }

        public bool IsEmpty()
        {
            return this.creditCards.IsEmpty();
        }

        public int Count()
        {
            return this.creditCards.Count();
        }

        public List<CreditCard> ListCreditCards()
        {
            return this.creditCards.ListCreditCards();
        }

        public List<CreditCard> GetMatchingCreditCards(List<CreditCard> creditCardsOnDataBreach)
        {
            List<CreditCard> creditCardsLeaked = this.creditCards.GetMatchingCreditCards(creditCardsOnDataBreach);
            return creditCardsLeaked;
        }

        public bool ContainsCreditCard(CreditCard creditCard) 
        {
            return this.creditCards.ContainsCreditCard(creditCard);
        }
    }
}
