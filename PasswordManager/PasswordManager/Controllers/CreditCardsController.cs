using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Controllers
{
    public class CreditCardsController
    {
        private CreditCardRepository CreditCards;

        public CreditCardsController(CreditCardRepository creditCards)
        {
            this.CreditCards = creditCards;
        }

    }
}
