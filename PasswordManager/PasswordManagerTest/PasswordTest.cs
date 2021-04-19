using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordManager;

namespace PasswordManagerTest
{
    [TestClass]
    public class PasswordTest
    {
        Password passwordTest;
        private Category personal;
        private string password = "admin";
        private string site = "aulas.ort.edu.uy";
        private string user = "Ralph";
        private string note = "";

        [TestInitialize]
        public void setup()
        {
            personal = new Category("Personal");
            passwordTest = new Password(personal, password, site, user, note);
        }

        [TestMethod]
        public void CreatePassword()
        {
            Assert.IsNotNull(passwordTest);
        }

    }
}