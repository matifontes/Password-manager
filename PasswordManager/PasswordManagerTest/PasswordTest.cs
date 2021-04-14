using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PasswordManagerTest
{
    [TestClass]
    public class PasswordTest
    {
        [TestMethod]
        public void CreatePassword()
        {
            Password passwordTest = new Password();
            Assert.IsNotNull(passwordTest);
        }
    }
}