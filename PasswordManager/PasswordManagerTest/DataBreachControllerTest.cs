using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PasswordManager.Controllers;
using PasswordManager;
using PasswordManager.Exceptions;
using PasswordManager.Repositories;

namespace PasswordManagerTest
{
    [TestClass]
    public class DataBreachControllerTest
    {

        List<CreditCard> cards;
        List<Password> passwords;
        DataBreach dBreach;
        DataBreachesRepository dataBreachesRepository;
        DataBreachesController dBreachController;

        [TestInitialize]
        public void Setup()
        {
            cards = new List<CreditCard>();
            passwords = new List<Password>();
            dBreach = new DataBreach(cards, passwords);
            dataBreachesRepository = new DataBreachesRepository();
            dBreachController = new DataBreachesController(dataBreachesRepository);
        }

        [TestCleanup]
        public void Cleanup()
        {
            cards = null;
            passwords = null;
            dBreach = null;
            dataBreachesRepository = null;
            dBreachController = null;
        }
        [TestMethod]
        public void CreateDataBreachController()
        {
            Assert.IsNotNull(dBreachController);
        }

        [TestMethod]
        public void DataBreachIsEmpty()
        {
            Assert.IsTrue(dBreachController.IsEmpty());
        }

        [TestMethod]
        public void AddDataBreach()
        {
            dBreachController.AddDataBreach(dBreach);
            Assert.IsFalse(dBreachController.IsEmpty());
        }

        [TestMethod]
        public void ListDataBreaches()
        {
            DataBreach dBreach01 = new DataBreach(cards, passwords);
            DataBreach dBreach02 = new DataBreach(cards, passwords);
            dBreachController.AddDataBreach(dBreach01);
            dBreachController.AddDataBreach(dBreach02);
            List<DataBreach> dBreachesList = dBreachController.ListDataBreaches();
            Assert.AreEqual(dBreach01, dBreachesList[0]);
            Assert.AreEqual(dBreach02, dBreachesList[1]);
        }

        [TestMethod]
        public void PasswordExistOnDataBreaches()
        {
            Password password = new Password("passTest123");
            this.passwords.Add(password);
            DataBreach dBreach01 = new DataBreach(cards, passwords);
            DataBreach dBreach02 = new DataBreach(cards, passwords);
            dBreachController.AddDataBreach(dBreach01);
            dBreachController.AddDataBreach(dBreach02);
            Assert.IsTrue(dBreachController.PasswordExistOnDataBreaches(password));
        }

        [TestMethod]
        public void PasswordDoesntExistOnDataBreaches()
        {
            Password password = new Password("passTest123");
            DataBreach dBreach01 = new DataBreach(cards, passwords);
            DataBreach dBreach02 = new DataBreach(cards, passwords);
            dBreachController.AddDataBreach(dBreach01);
            dBreachController.AddDataBreach(dBreach02);
            Assert.IsFalse(dBreachController.PasswordExistOnDataBreaches(password));
        }

    }
}
