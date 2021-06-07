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
        [TestMethod]
        public void CreateDataBreachesRepository()
        {
            DataBreachesRepositoryTest dataBreaches = new DataBreachesRepositoryTest();
            Assert.IsNotNull(dataBreaches);
        }


        [TestMethod]
        public void CreateNewDataBreachesRepositoryShouldBeEmpty()
        {
            List<CreditCard> cards = new List<CreditCard>();
            List<Password> passwords = new List<Password>();
            DataBreach dBreach = new DataBreach(cards, passwords);

            DataBreachesRepository dataBreachesRepository = new DataBreachesRepository();
            Assert.IsTrue(dataBreachesRepository.IsEmpty());
        }

    }
}
