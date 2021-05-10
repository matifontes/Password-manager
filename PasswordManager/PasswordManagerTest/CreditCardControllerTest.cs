using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordManager.Controllers;
using PasswordManager;
namespace PasswordManagerTest
{
    [TestClass]
    public class CreditCardControllerTest
    {
        private CreditCardRepository creditCards;
        private CreditCardsController creditCardsController;
        private CreditCard card;
        private Category category = new Category("Work");
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
        public void CreditCardControllerWithAPasswordShouldntBeEmpty()
        {
            creditCardsController.AddCreditCard(card);
            Assert.IsFalse(creditCardsController.IsEmpty());
        }

    }
}
