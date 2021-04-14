using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PasswordManager;

namespace PasswordManagerTest
{
    [TestClass]
    public class UserTest
    {
        private User profile;
        private string validPassword = "admin";

        [TestInitialize]
        public void Setup()
        {
            profile = new User(validPassword);
        }

        [TestMethod]
        public void CreateUser()
        {
            Assert.IsNotNull(profile);
        }

        [TestMethod]
        public void ValidatePasswordParameterOnUserCreation()
        {
            Assert.AreEqual(profile.SystemPassword, validPassword);
        }
    }
}
