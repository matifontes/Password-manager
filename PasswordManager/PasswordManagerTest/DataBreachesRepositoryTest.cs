using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using PasswordManager;
using PasswordManager.Repositories;
using PasswordManager.Exceptions;

namespace PasswordManagerTest
{
    [TestClass]
    public class DataBreachesRepositoryTest
    {
        List<CreditCard> cards;
        List<Password> passwords;
        DataBreach dBreach;
        DataBreachesRepository dataBreachesRepository;
        Password password;

        [TestInitialize]
        public void Setup() {
            cards = new List<CreditCard>();
            passwords = new List<Password>();
            password = new Password("Passtest123");
            dBreach = new DataBreach(cards, passwords);
            dataBreachesRepository = new DataBreachesRepository();
        }

        [TestCleanup]
        public void Cleanup()
        {
            cards = null;
            passwords = null;
            dBreach = null;
            password = null;
            dataBreachesRepository = null;
        }
    
        
    [TestMethod]
        public void CreateDataBreachesRepository()
        {
            Assert.IsNotNull(dataBreachesRepository);
        }


        [TestMethod]
        public void AddDataBreachToRepository()
        {
            dataBreachesRepository.AddDataBreach(dBreach);
            Assert.IsFalse(dataBreachesRepository.IsEmpty());
        }

        [TestMethod]
        public void CreateNewDataBreachesRepositoryShouldBeEmpty()
        {
            Assert.IsTrue(dataBreachesRepository.IsEmpty());
        }

        [TestMethod]
        public void AddCreditCardToRepositoryShouldntBeEmpty()
        {
            dataBreachesRepository.AddDataBreach(dBreach);
            Assert.IsFalse(dataBreachesRepository.IsEmpty());
        }

        [TestMethod]
        public void ListDataBreaches()
        {
            DataBreach dBreach01 = new DataBreach(cards, passwords);
            DataBreach dBreach02 = new DataBreach(cards, passwords);
            dataBreachesRepository.AddDataBreach(dBreach01);
            dataBreachesRepository.AddDataBreach(dBreach02);
            List<DataBreach> dBreachesList = dataBreachesRepository.ListDataBreaches();
            Assert.AreEqual(dBreach01, dBreachesList[0]);
            Assert.AreEqual(dBreach02, dBreachesList[1]);
        }

        [TestMethod]
        public void PasswordExistOnDataBreaches()
        {
            this.passwords.Add(password);
            DataBreach dBreach01 = new DataBreach(cards, passwords);
            DataBreach dBreach02 = new DataBreach(cards, passwords);
            dataBreachesRepository.AddDataBreach(dBreach01);
            dataBreachesRepository.AddDataBreach(dBreach02);
            Assert.IsTrue(dataBreachesRepository.PasswordExistOnDataBreaches(password));
        }
        [TestMethod]
        public void PasswordDoesntExistOnDataBreaches()
        {
            DataBreach dBreach01 = new DataBreach(cards, passwords);
            DataBreach dBreach02 = new DataBreach(cards, passwords);
            dataBreachesRepository.AddDataBreach(dBreach01);
            dataBreachesRepository.AddDataBreach(dBreach02);
            Assert.IsFalse(dataBreachesRepository.PasswordExistOnDataBreaches(password));
        }

        public void CheckEquals()
        {
            string passString = password.Pass;
            Assert.IsTrue(password.Pass.Equals(passString));
        }

    }
}
