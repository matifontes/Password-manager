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
        [TestMethod]
        public void CreateDataBreachController()
        {
            DataBreachesRepository dBreaches = new DataBreachesRepository();
            DataBreachesController dBreachController = new DataBreachesController(dBreaches);
            Assert.IsNotNull(dBreachController);
        }
    }
}
