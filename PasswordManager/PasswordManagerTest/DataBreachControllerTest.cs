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
        public void AddDataBreach()
        {
            dBreachController.AddDataBreach(dBreach);
            Assert.AreEqual(dBreachController.Count(), 1);
        }

    }
}
