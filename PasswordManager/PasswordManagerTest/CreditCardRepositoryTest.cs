using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using PasswordManager;

namespace PasswordManagerTest
{
    [TestClass]
    public class CreditCardRepositoryTest
    {
        private CreditCardRepository creditCardRepository;
        private Category category;
        private CreditCard creditCard;
        private string name = "Visa";
        private string type = "Visa Gold";
        private long creditCardNumber = 2341232123212312;
        private short ccvCode = 080;
        private DateTime expDate = new DateTime(2021, 5, 1);
        private string note = "Note";

        [TestInitialize]
        public void Setup() 
        {
            category = new Category("Personal");
            creditCard = new CreditCard(category, name, type, creditCardNumber, ccvCode, expDate, note);
            creditCardRepository = new CreditCardRepository();
        }

        [TestCleanup]
        public void Cleanup() 
        {
            category = null;
            creditCard = null;
            creditCardRepository = null;
        }

        [TestMethod]
        public void CreateCreditCardRepository()
        {
            Assert.IsNotNull(creditCardRepository);
        }

        [TestMethod]
        public void CreateNewCreditCardRepositoryShouldBeEmpty() 
        {
            Assert.IsTrue(creditCardRepository.IsEmpty());
        }

        [TestMethod]
        public void AddCreditCardToRepository() 
        {
            creditCardRepository.AddCreditCard(creditCard);
            Assert.AreEqual(creditCardRepository.Count(), 1);
        }

        [TestMethod]
        public void AddCreditCardToRepositoryShouldntBeEmpty()
        {
            creditCardRepository.AddCreditCard(creditCard);
            Assert.IsFalse(creditCardRepository.IsEmpty());
        }

        [TestMethod]
        public void RemoveCreditCardFromRepository() 
        {
            creditCardRepository.AddCreditCard(creditCard);
            creditCardRepository.RemoveCreditCard(creditCard);
            Assert.AreEqual(creditCardRepository.Count(), 0);
        }

        [TestMethod]
        public void RemoveCreaditCardThatDoesntExistOnRepository() 
        {
            creditCardRepository.AddCreditCard(creditCard);
            string name = "Visa";
            string type = "Visa Black";
            long creditCardNumber = 5665321232123124;
            short ccvCode = 120;
            DateTime expDate = new DateTime(2021, 5, 1);
            string note = "Note";
            CreditCard otherCreditCard = new CreditCard(category, name, type, creditCardNumber, ccvCode, expDate, note);
            
            creditCardRepository.RemoveCreditCard(otherCreditCard);
            Assert.AreEqual(creditCardRepository.Count(), 1);
        }

        [TestMethod]
        public void ListCreditCardssOrderByCategory()
        {
            Category category2 = new Category("Trabajo");
            Category category3 = new Category("Gaming");
            CreditCard card2 = new CreditCard(category2, name, type, creditCardNumber, ccvCode, expDate, note);
            CreditCard card3 = new CreditCard(category3, name, type, creditCardNumber, ccvCode, expDate, note);
            creditCardRepository.AddCreditCard(card3);
            creditCardRepository.AddCreditCard(creditCard);
            creditCardRepository.AddCreditCard(card2);


            List<CreditCard> orderedCreditCards = creditCardRepository.ListCreditCards();
            Assert.AreEqual(orderedCreditCards[0].Category, category3);
            Assert.AreEqual(orderedCreditCards[1].Category, category);
            Assert.AreEqual(orderedCreditCards[2].Category, category2);
        }

        [TestMethod]
        public void GetMatchingCreditCardsList()
        {
            Category category2 = new Category("Trabajo");
            Category category3 = new Category("Gaming");
            CreditCard card2 = new CreditCard(category2, name, type, creditCardNumber, ccvCode, expDate, note);
            CreditCard card3 = new CreditCard(category3, name, type, creditCardNumber, ccvCode, expDate, note);
            creditCardRepository.AddCreditCard(card3);
            creditCardRepository.AddCreditCard(card2);


            List<CreditCard> creditCards = new List<CreditCard>();
            creditCards.Add(card2);
            List<CreditCard> creditCardsResult = creditCardRepository.GetMatchingCreditCardsList(creditCards);
            Assert.AreEqual(card2, creditCardsResult[0]);
        }
    }
}
