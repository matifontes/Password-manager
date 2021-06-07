using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PasswordManager;
using System.Collections.Generic;
using PasswordManager.Controllers;
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

        [TestInitialize]
        public void Setup()
        {
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
        public void CreateDataBreachController()
        {
            DataBreachesRepository dBreaches = new DataBreachesRepository();
            DataBreachesController dBreachController = new DataBreachesController(dBreaches);
            Assert.IsNotNull(dBreachController);
        }

    }
}
