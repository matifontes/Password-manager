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

        public bool IsEmpty()
        {
            bool isEmpty = this.creditCards.Count() == 0;
            return isEmpty;
        }

    }
}
