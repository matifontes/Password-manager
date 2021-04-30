using System;
using PasswordManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PasswordManagerTest
{
    [TestClass]
    public class PasswordGenerateTest
    {
        [TestMethod]
        public void GeneratePassword()
        {
            string password = PasswordGenerator.GeneratePassword();
            Assert.IsNotNull(password);
        }
    }
}
