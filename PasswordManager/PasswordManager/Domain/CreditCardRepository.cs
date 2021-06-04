using System.Collections.Generic;
using System.Linq;
using PasswordManager.Exceptions;

namespace PasswordManager
{
    public class CreditCardRepository
    {
        private List<CreditCard> creditCards;
        public CreditCardRepository() 
        {
            creditCards = new List<CreditCard>();
        }

        public void AddCreditCard(CreditCard creditCard) 
        {
            if (this.ContainsCreditCard(creditCard))
            {
                const string CREDIT_CARD_ALREADY_EXISTS_MSG = "La Tarjeta de credito ya existe";
                throw new CreditCardAlreadyExistsException(CREDIT_CARD_ALREADY_EXISTS_MSG);
            }
            else 
            {
                this.creditCards.Add(creditCard);
            }

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
            return this.creditCards.OrderBy(creditCard => creditCard.Category.ToString()).ToList();
        }

        public bool ContainsCreditCard(CreditCard creditCard) 
        {
            foreach (CreditCard cards in this.creditCards) 
            {
                if (cards.IsEqual(creditCard)) 
                {
                    return true;
                }
            }
            return false;
        }

        public List<CreditCard> GetMatchingCreditCards(List<CreditCard> creditCardsOnDataBreach)
        {
            List<CreditCard> creditCardsLeaked = new List<CreditCard>();
            foreach (CreditCard credCardInRepo in this.creditCards)
            {
                foreach (CreditCard creditCardInBreach in creditCardsOnDataBreach)
                {
                    if (credCardInRepo.Number.Equals(creditCardInBreach.Number) && !creditCardsLeaked.Contains(credCardInRepo))
                    {
                        creditCardsLeaked.Add(credCardInRepo);
                    }
                }
            }
            return creditCardsLeaked;
        }

    }
}