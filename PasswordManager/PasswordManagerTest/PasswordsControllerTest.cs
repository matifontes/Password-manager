using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PasswordManager;
using PasswordManager.Controllers;
using PasswordManager.Exceptions;
using System.Collections.Generic;

namespace PasswordManagerTest
{
    [TestClass]
    public class PasswordsControllerTest
    {
        private PasswordRepository passwords;
        private PasswordsController passwordsController;
        private Category category;
        Password password;
        private string pass = "admin";
        private string site = "aulas.ort.edu.uy";
        private string user = "Ralph";
        private string note = "";

        [TestInitialize]
        public void Setup() 
        {
            passwords = new PasswordRepository();
            category = new Category("Personal");
            password = new Password(category, pass, site, user, note);
            passwordsController = new PasswordsController(passwords);
        }

        [TestCleanup]
        public void Cleanup() 
        {
            passwords = null;
            category = null;
            password = null;
            passwordsController = null;
        }

        [TestMethod]
        public void CreatePasswordsController()
        {
            Assert.IsNotNull(passwordsController);
        }

        [TestMethod]
        public void CreateNewPasswordsControllerShouldBeEmpty() 
        {
            Assert.IsTrue(passwordsController.IsEmpty());
        }

        [TestMethod]
        public void AddPassword() 
        {
            passwordsController.AddPassword(password);
            Assert.AreEqual(passwordsController.Count(), 1);
        }

        [TestMethod]
        public void PasswordsControllerWithAPasswordShouldntBeEmpty()
        {
            passwordsController.AddPassword(password);
            Assert.IsFalse(passwordsController.IsEmpty());
        }

        [TestMethod]
        public void RemovePassword() 
        {
            passwordsController.AddPassword(password);
            passwordsController.RemovePassword(password);

            Assert.AreEqual(passwordsController.Count(), 0);
        }

        [TestMethod]
        public void ListPasswordsOrderByCategory()
        {
            Category category2 = new Category("Trabajo");
            Category category3 = new Category("Gaming");
            Password password2 = new Password(category2,pass,site,user,note);
            Password password3 = new Password(category3,pass,site,user,note);
            passwordsController.AddPassword(password);
            passwordsController.AddPassword(password2);
            passwordsController.AddPassword(password3);

            List<Password> orderedPassword = passwordsController.ListPasswords();
            Assert.AreEqual(orderedPassword[0].Category,category3);
            Assert.AreEqual(orderedPassword[1].Category, category);
            Assert.AreEqual(orderedPassword[2].Category, category2);
        }
    }
}
