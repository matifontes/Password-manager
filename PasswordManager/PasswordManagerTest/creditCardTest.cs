using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordManager;
using PasswordManager.Exceptions;
using System;

namespace PasswordManagerTest
{
    [TestClass]
    public class CreditCardTest
    {
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
        }

        [TestCleanup]
        public void Cleanup()
        {
            card = null;
        }

        [TestMethod]
        public void CreateCreditCard()
        {
            Assert.IsNotNull(card);
        }

        [TestMethod]
        public void CreateCreditCardWithValidNumber() 
        {
            Assert.AreEqual(card.Number,creditCardNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCreditCardNumberException))]
        public void CreateCreditCardWithNumberLenghtLessThanSixteen()
        {
            long creditCardShortNumber = 12345;
            CreditCard invalidCard = new CreditCard(category, name, type, creditCardShortNumber, ccvCode, expDate, note);
        }

        [TestMethod]
        [ExpectedException(typeof(EmptyCreditCardNameException))]
        public void CreateCreditCardWithEmptyNameThrowsException() 
        {
            new CreditCard(category, "", type, creditCardNumber, ccvCode, expDate, note);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCreditCardNumberException))]
        public void CreateCreditCardWithNumberLenghtLongerThanSixteen()
        {
            long creditCardLongNumber = 123451234512345123;
            CreditCard invalidCard = new CreditCard(category, name, type, creditCardLongNumber, ccvCode, expDate, note);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCreditCardCCVCodeException))]
        public void CreateCreditCardWithInvalidCCVCode() 
        {
            short InvalidCCVCode = 12112; 
            CreditCard invalidCard = new CreditCard(category, name, type, creditCardNumber, InvalidCCVCode, expDate, note);
        }

        [TestMethod]
        public void CreditCardToStringShowItsName() 
        {
            Assert.AreEqual(card.ToString(), name);
        }

    }
}
