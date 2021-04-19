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
            Category category = new Category("Work");
            string name = "Visa Gold";
            string type = "Visa";
            long number = 2323321323212321;
            short ccvCode = 080;
            DateTime expDate = new DateTime(2021, 5, 1);
            string note = "card for USA";

            CreditCard card = new CreditCard(category,name,type,number,ccvCode,expDate,note);
            Assert.IsNotNull(card);
        }
    }
}
