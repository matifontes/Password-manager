﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PasswordManager;

namespace PasswordManagerTest
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void CreateUser()
        {
            string password = "admin";

            User profile = new User(password);
            Assert.IsNotNull(profile);
        }
    }
}
