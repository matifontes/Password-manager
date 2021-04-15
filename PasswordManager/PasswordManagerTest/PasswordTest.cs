using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordManager;

namespace PasswordManagerTest
{
    [TestClass]
    public class PasswordTest
    {
        Password passwordTest;
        private Categorie personal;
        private string password = "admin";
        private string site = "aulas.ort.edu.uy";
        private string user = "Ralph";
        private string note = "";

        [TestInitialize]
        public void setup()
        {
            personal = new Categorie("Personal");
            passwordTest = new Password(personal, password, site, user, note);
        }

        [TestMethod]
        public void CreatePassword()
        {
            Assert.IsNotNull(passwordTest);
        }

        [TestMethod]
        public void checkPasswordCategorie()
        {
            Assert.AreEqual(passwordTest.Categorie, personal);
        }

        [TestMethod]
        public void checkPassword()
        {
            Assert.AreEqual(passwordTest.Pass, password);
        }

        [TestMethod]
        public void checkPasswordSite()
        {
            Assert.AreEqual(passwordTest.Site, site);
        }

        [TestMethod]
        public void checkPasswordUser()
        {
            Assert.AreEqual(passwordTest.User, user);
        }

        [TestMethod]
        public void checkPasswordNote()
        {
            Assert.AreEqual(passwordTest.Note, note);
        }


    }
}