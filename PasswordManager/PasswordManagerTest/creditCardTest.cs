using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordManager;
using System;

namespace PasswordManagerTest
{
    [TestClass]
    public class CreditCardTest
    {
        private SystemProfile systemProfile;
        private CreditCard card;
        private Category category = new Category("Work");
        private string name = "Visa Gold";
        private string type = "Visa";
        private long creditCardNumber = 2323321323212321;
        private short ccvCode = 080;
        private DateTime expDate = new DateTime(2021, 5, 1);
        private string note = "card for USA";

        [TestInitialize]
        public void setup()
        {
            card = new CreditCard(category, name, type, creditCardNumber, ccvCode, expDate, note);
            systemProfile = null;
        }

        [TestMethod]
        public void CreateCreditCard()
        {
            Assert.IsNotNull(card);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCreditCardNumberException))]
        public void CreateCreditCardWitNumberLenghtLessThanSixteen()
        {
            long creditCardShortNumber = 12345;
            CreditCard invalidCard = new CreditCard(category, name, type, creditCardShortNumber, ccvCode, expDate, note);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCreditCardNumberException))]
        public void CreateCreditCardWitNumberLenghtLongerThanSixteen()
        {
            long creditCardLongNumber = 123451234512345123;
            CreditCard invalidCard = new CreditCard(category, name, type, creditCardLongNumber, ccvCode, expDate, note);
        }


    }
}
