using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordManager;
using System;

namespace PasswordManagerTest
{
    [TestClass]
    public class CreditCardTest
    {
        [TestMethod]
        public void CreateCreditCard()
        {
            CreditCard card = new CreditCard();
            Assert.IsNotNull(card);
        }
    }
}
