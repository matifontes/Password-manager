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
        [TestMethod]
        public void CreateDataBreach()
        {
            List<CreditCard> creditCards = new List<CreditCard>();
            List<Password> passwords = new List<Password>();

            DataBreach dBreachTest = new DataBreach(creditCards, passwords);
        }
    }
}
