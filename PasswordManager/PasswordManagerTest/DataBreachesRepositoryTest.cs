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

        [TestInitialize]
        public void Setup() {
            cards = new List<CreditCard>();
            passwords = new List<Password>();
            dBreach = new DataBreach(cards, passwords);
            dataBreachesRepository = new DataBreachesRepository();
        }

        [TestCleanup]
        public void Cleanup()
        {
            cards = null;
            passwords = null;
            dBreach = null;
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
            Password password = new Password("Passtest123");
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
            Password password = new Password("Passtest123");
            DataBreach dBreach01 = new DataBreach(cards, passwords);
            DataBreach dBreach02 = new DataBreach(cards, passwords);
            dataBreachesRepository.AddDataBreach(dBreach01);
            dataBreachesRepository.AddDataBreach(dBreach02);
            Assert.IsFalse(dataBreachesRepository.PasswordExistOnDataBreaches(password));
        }

    }
}
