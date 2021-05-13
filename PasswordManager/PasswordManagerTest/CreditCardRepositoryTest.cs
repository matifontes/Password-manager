using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using PasswordManager;
using PasswordManager.Exceptions;

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
        public void ListCreditCardsOrderByCategory()
        {
            Category category2 = new Category("Trabajo");
            Category category3 = new Category("Gaming");
            long creditCardNumberForCard2 = 1234123412341234;
            long creditCardNumberForCard3 = 6789678967896789;
            CreditCard card2 = new CreditCard(category2, name, type, creditCardNumberForCard2, ccvCode, expDate, note);
            CreditCard card3 = new CreditCard(category3, name, type, creditCardNumberForCard3, ccvCode, expDate, note);
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
            long cardNumber2 = 1111222233334444;
            long cardNumber3 = 1111222233335555;
            CreditCard card2 = new CreditCard(category2, name, type, cardNumber2, ccvCode, expDate, note);
            CreditCard card3 = new CreditCard(category3, name, type, cardNumber3, ccvCode, expDate, note);
            creditCardRepository.AddCreditCard(card3);
            creditCardRepository.AddCreditCard(card2);


            List<CreditCard> creditCards = new List<CreditCard>();
            creditCards.Add(card2);
            List<CreditCard> creditCardsResult = creditCardRepository.GetMatchingCreditCardsList(creditCards);
            Assert.AreEqual(card2.Number, creditCardsResult[0].Number);
        }

        public void RepositoryContainsCreditCardAddedToIt() 
        {
            creditCardRepository.AddCreditCard(creditCard);
            Assert.IsTrue(creditCardRepository.ContainsCreditCard(creditCard));
        }

        [TestMethod]
        [ExpectedException(typeof(CreditCardAlreadyExistsException))]
        public void AddCreditCardThatAlreadyExistrsThrowsException() 
        {
            creditCardRepository.AddCreditCard(creditCard);
            creditCardRepository.AddCreditCard(creditCard);
        }

        [TestMethod]
        [ExpectedException(typeof(CreditCardAlreadyExistsException))]
        public void AddCreditCardWhitSameNumberThenAnotherCardThrowsException()
        {
            creditCardRepository.AddCreditCard(creditCard);
            string name = "Master Black";
            string type = "MasterCard";
            short ccvCode = 091;
            string note = "note";

            CreditCard sameCreditcard = new CreditCard(category,name,type,creditCardNumber,ccvCode,DateTime.Now,note);
            creditCardRepository.AddCreditCard(sameCreditcard);
        }
    }
}
