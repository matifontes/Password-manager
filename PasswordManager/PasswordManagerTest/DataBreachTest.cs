using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManager;

namespace PasswordManagerTest
{
    [TestClass]
    public class DataBreachTest
    {
        List<CreditCard> creditCards;
        List<Password> passwords;

        [TestInitialize]
        public void Setup()
        {
            creditCards = new List<CreditCard>();
            passwords = new List<Password>();
        }

        [TestCleanup]
        public void Cleanup()
        {
            creditCards = null;
            passwords = null;
        }

        [TestMethod]
        public void CreateDataBreach()
        {
            DataBreach dBreachTest = new DataBreach(creditCards, passwords);
            Assert.IsNotNull(dBreachTest);
        }

        [TestMethod]
        public void CheckDateofDataBreach()
        {
            DateTime nowDateTime = DateTime.Now;
            DataBreach dBreachDateTest = new DataBreach(creditCards, passwords);
            
            Assert.AreEqual(nowDateTime, dBreachDateTest.Date);
        }
    }
}
