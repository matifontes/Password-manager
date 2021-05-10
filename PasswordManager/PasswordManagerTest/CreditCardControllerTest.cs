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

        [TestInitialize]
        public void Setup()
        {
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


    }
}
