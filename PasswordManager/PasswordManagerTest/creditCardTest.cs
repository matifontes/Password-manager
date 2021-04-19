using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordManager;
using System;

namespace PasswordManagerTest
{
    [TestClass]
    public class creditCardTest
    {
        [TestMethod]
        public void CreateCreditCard()
        {
            creditCard card = new creditCard();
            Assert.IsNotNull(card);
        }
    }
}
