using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordManager;
namespace PasswordManagerTest
{
    [TestClass]
    public class CreditCardControllerTest
    {
        [TestMethod]
        public void CreateCreditCardController()
        {
            CreditCardRepository creditCards = new CreditCardRepository();
            CreditCardController creditCardsController = new CreditCardsController(creditCards);
            Assert.IsNotNull(creditCardsController);
        }
    }
}
