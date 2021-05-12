using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PasswordManager.Controllers;
using PasswordManager;
using PasswordManager.Exceptions;

namespace PasswordManagerTest
{
    [TestClass]
    public class CreditCardControllerTest
    {
        private CreditCardRepository creditCards;
        private CreditCardsController creditCardsController;
        private CreditCard card;
        private Category category = new Category("Personal");
        private string name = "Visa Gold";
        private string type = "Visa";
        private long creditCardNumber = 2323321323212321;
        private short ccvCode = 080;
        private DateTime expDate = new DateTime(2021, 5, 1);
        private string note = "card for USA";

        [TestInitialize]
        public void Setup()
        {
            card = new CreditCard(category, name, type, creditCardNumber, ccvCode, expDate, note);
            creditCards = new CreditCardRepository();
            creditCardsController = new CreditCardsController(creditCards);
        }

        [TestCleanup]
        public void Cleanup()
        {
            creditCards = null;
            creditCardsController = null;
        }

        [TestMethod]
        public void CreateCreditCardController()
        {
            Assert.IsNotNull(creditCardsController);
        }

        [TestMethod]
        public void CreateNewCreditCardsControllerShouldBeEmpty()
        {
            Assert.IsTrue(creditCardsController.IsEmpty());
        }

        [TestMethod]
        public void AddCreditCard()
        {
            creditCardsController.AddCreditCard(card);
            Assert.AreEqual(creditCardsController.Count(), 1);
        }

        [TestMethod]
        [ExpectedException(typeof(CreditCardAlreadyExistsException))]
        public void AddCreditCardThatAlreadyExistsThrowsException() 
        {
            creditCardsController.AddCreditCard(card);
            creditCardsController.AddCreditCard(card);
        }

        [TestMethod]
        public void CreditCardAddedToControllerContainsIt()
        {
            creditCardsController.AddCreditCard(card);
            Assert.IsTrue(creditCardsController.Contains(card));
        }

        [TestMethod]
        public void CreditCardControllerWithAPasswordShouldntBeEmpty()
        {
            creditCardsController.AddCreditCard(card);
            Assert.IsFalse(creditCardsController.IsEmpty());
        }

        [TestMethod]
        public void RemoveCreditCard()
        {
            creditCardsController.AddCreditCard(card);
            creditCardsController.RemoveCreditCard(card);

            Assert.AreEqual(creditCardsController.Count(), 0);
        }

        [TestMethod]
        public void ListCreditCardssOrderByCategory()
        {
            Category category2 = new Category("Trabajo");
            Category category3 = new Category("Gaming");
            long creditCardNumberForCard2 = 1234123412341234;
            long creditCardNumberForCard3 = 4321432143214321;
            CreditCard card2 = new CreditCard(category2, name, type, creditCardNumberForCard2, ccvCode, expDate, note);
            CreditCard card3 = new CreditCard(category3, name, type, creditCardNumberForCard3, ccvCode, expDate, note);
            creditCardsController.AddCreditCard(card);
            creditCardsController.AddCreditCard(card2);
            creditCardsController.AddCreditCard(card3);


            List<CreditCard> orderedCreditCards = creditCardsController.ListCreditCards();
            Assert.AreEqual(orderedCreditCards[0].Category, category3);
            Assert.AreEqual(orderedCreditCards[1].Category, category);
            Assert.AreEqual(orderedCreditCards[2].Category, category2);
        }
    }
}
