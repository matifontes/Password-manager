﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using PasswordManager;

namespace PasswordManagerTest
{
    [TestClass]
    public class DataBreachesRepository
    {
        [TestMethod]
        public void CreateDataBreachesRepository()
        {
            DataBreachesRepository dataBreaches = new DataBreachesRepository();
            Assert.IsNotNull(dataBreaches);
        }
    }
}
