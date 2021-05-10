using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordManager.Controllers;
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
            CreditCardsController creditCardsController = new CreditCardsController(creditCards);
            
            Assert.IsNotNull(creditCardsController);
        }
    }
}
