using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordManager;

namespace PasswordManagerTest
{
    [TestClass]
    public class PasswordTest
    {
        private Categorie personal;
        private string password = "admin";
        private string site = "aulas.ort.edu.uy";
        private string user = "Ralph";
        private string note = "";

        [TestInitialize]
        public void setup()
        {
            personal = new Categorie("Personal");
        }

        [TestMethod]
        public void CreatePassword()
        {
            Password passwordTest = new Password();
            Assert.IsNotNull(passwordTest);
        }
    }
}