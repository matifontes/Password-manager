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
        public void CreateCreditCardOnlyWithNumber()
        {
            long creditCardNumber = 2145321155556688;
            CreditCard creditCardTest = new CreditCard(creditCardNumber);
            Assert.IsNotNull(creditCardTest);
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
        [ExpectedException(typeof(InvalidCreditCardNameException))]
        public void CreateCreditCardWithNameLongerThan25ThrowsException() 
        {
            string name = "1234567890ABCDEFGHRSDAWRFS";
            new CreditCard(category, name, type, creditCardNumber, ccvCode, expDate, note);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCreditCardNameException))]
        public void CreateCreditCardWithNameShorterThan3ThrowsException()
        {
            string name = "a2";
            new CreditCard(category, name, type, creditCardNumber, ccvCode, expDate, note);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCreditCardTypeException))]
        public void CreateCreaditCardWithTypeShorterThan3ThrowsException() 
        {

            string type = "ab";
            new CreditCard(category, name, type, creditCardNumber, ccvCode, expDate, note);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCreditCardTypeException))]
        public void CreateCreaditCardWithTypeLargerThan25ThrowsException()
        {

            string type = "1234567890ABCDEFGHRSDAWRFS";
            new CreditCard(category, name, type, creditCardNumber, ccvCode, expDate, note);
        }

        [TestMethod]
        public void GetCreditCardType()
        {
            CreditCard creaditCard = new CreditCard(category, name, type, creditCardNumber, ccvCode, expDate, note);
            Assert.AreEqual(type, creaditCard.Type);
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
        public void GetCreditCardCCVCode()
        {
            CreditCard creaditCard = new CreditCard(category, name, type, creditCardNumber, ccvCode, expDate, note);
            Assert.AreEqual(ccvCode, creaditCard.CCVCode);
        }

        [TestMethod]
        public void CreditCardToStringShowItsName() 
        {
            Assert.AreEqual(card.ToString(), name);
        }

        [TestMethod]
        public void CreditCardsAreEqualIfTheyHaveTheSameNumber() 
        {
            CreditCard sameCard = new CreditCard(category,name,type,creditCardNumber,ccvCode,expDate,note);
            Assert.IsTrue(card.IsEqual(sameCard));
        }

        [TestMethod]
        public void CreditCardsAreDifferentIfTheyHaveDifferentNumber()
        {
            long creditCardNumber = 1234123412341234;
            CreditCard sameCard = new CreditCard(category, name, type, creditCardNumber, ccvCode, expDate, note);
            Assert.IsFalse(card.IsEqual(sameCard));
        }

        [TestMethod]
        public void VerifyCreditCardId()
        {
            card.Id = 1;

            Assert.AreEqual(1, card.Id);
        }
    }
}
