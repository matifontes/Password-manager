using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PasswordManager;

namespace PasswordManagerTest
{
    [TestClass]
    public class UserTest
    {
        private User profile;
        private string password = "admin";

        [TestInitialize]
        public void setup()
        {
            profile = new User(password);
        }

        [TestMethod]
        public void CreateUser()
        {
            Assert.IsNotNull(profile);
        }

        [TestMethod]
        public void validatePasswordParameterOnUserCreation()
        {
            Assert.AreEqual(profile.Password, password);
        }
    }
}
