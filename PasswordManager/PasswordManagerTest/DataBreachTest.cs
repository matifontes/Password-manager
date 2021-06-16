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
        DataBreach dBreachTest;
        DateTime nowDateTime;

        [TestInitialize]
        public void Setup()
        {
            creditCards = new List<CreditCard>();
            passwords = new List<Password>();
            nowDateTime = DateTime.Now;
            dBreachTest = new DataBreach(creditCards, passwords);
        }

        [TestCleanup]
        public void Cleanup()
        {
            creditCards = null;
            passwords = null;
            dBreachTest = null;
        }

        [TestMethod]
        public void CreateDataBreach()
        {
            Assert.IsNotNull(dBreachTest);
        }

        [TestMethod]
        public void CheckDateofDataBreach()
        {
            Assert.AreEqual(nowDateTime, dBreachTest.Date);
        }

        [TestMethod]
        public void CheckToString()
        {
            string toStringTest = "DataBreach: " + dBreachTest.Date;
            
            Assert.AreEqual(toStringTest, dBreachTest.ToString());
        }

        [TestMethod]
        public void VerifyDataBreachId()
        {
            dBreachTest.Id = 1;

            Assert.AreEqual(1, dBreachTest.Id);
        }
    }
}
