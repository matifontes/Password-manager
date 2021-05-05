﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PasswordManager;

namespace PasswordManagerTest
{
    [TestClass]
    public class CreditCardRepositoryTest
    {
        private CreditCardRepository creditCardRepository;
        private Category category;
        private CreditCard creditCard;
        private string name = "Visa";
        private string type = "Visa Gold";
        private long creditCardNumber = 2341232123212312;
        private short ccvCode = 080;
        private DateTime expDate = new DateTime(2021, 5, 1);
        private string note = "Note";

        [TestInitialize]
        public void Setup() 
        {
            category = new Category("Personal");
            creditCard = new CreditCard(category, name, type, creditCardNumber, ccvCode, expDate, note);
            creditCardRepository = new CreditCardRepository();
        }

        [TestCleanup]
        public void Cleanup() 
        {
            category = null;
            creditCard = null;
            creditCardRepository = null;
        }

        [TestMethod]
        public void CreateCreditCardRepository()
        {
            Assert.IsNotNull(creditCardRepository);
        }

        [TestMethod]
        public void AddCreditCardToRepository() 
        {
            creditCardRepository.AddCreditCard(creditCard);
            Assert.AreEqual(creditCardRepository.Count(), 1);
        }

        [TestMethod]
        public void RemoveCreditCardFromRepository() 
        {
            creditCardRepository.AddCreditCard(creditCard);
            creditCardRepository.RemoveCreditCard(creditCard);
            Assert.AreEqual(creditCardRepository.Count(), 0);
        }
    }
}
