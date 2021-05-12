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

        [TestMethod]
        public void ListRedPasswordsOrderByCategory()
        {
            Category category2 = new Category("Gaming");
            Password password2 = new Password(category2, pass, site, user, note);
            passwordsController.AddPassword(password);
            passwordsController.AddPassword(password2);

            List<Password> orderedRedPasswords = passwordsController.ListRedPasswords();
            Assert.AreEqual(orderedRedPasswords[0].Category, category2);
            Assert.AreEqual(orderedRedPasswords[1].Category, category);
        }

        [TestMethod]
        public void ListOrangePasswordsOrderByCategory()
        {
            Category category2 = new Category("Gaming");
            Password password2 = new Password(category2, "adminadmin", site, user, note);
            Password password = new Password(category, "adminadmin", site, user, note);
            passwordsController.AddPassword(password);
            passwordsController.AddPassword(password2);

            List<Password> orderedOrangePasswords = passwordsController.ListOrangePasswords();
            Assert.AreEqual(orderedOrangePasswords[0].Category, category2);
            Assert.AreEqual(orderedOrangePasswords[1].Category, category);
        }

        [TestMethod]
        public void ListYellowPasswordsOrderByCategory()
        {
            Category category2 = new Category("Gaming");
            Password password2 = new Password(category2, "adminadminadminadmin", site, user, note);
            Password password = new Password(category, "ADMINADMINADMINADMIN", site, user, note);
            passwordsController.AddPassword(password);
            passwordsController.AddPassword(password2);

            List<Password> orderedYellowPasswords = passwordsController.ListYellowPasswords();
            Assert.AreEqual(orderedYellowPasswords[0].Category, category2);
            Assert.AreEqual(orderedYellowPasswords[1].Category, category);
        }

        [TestMethod]
        public void ListLightGreenPasswordsOrderByCategory()
        {
            Category category2 = new Category("Gaming");
            Password password2 = new Password(category2, "adminADMINAdminAdminJk", site, user, note);
            Password password = new Password(category, "ADMINadminADMINadminAD", site, user, note);
            passwordsController.AddPassword(password);
            passwordsController.AddPassword(password2);

            List<Password> orderedLightGreenPasswords = passwordsController.ListLightGreenPasswords();
            Assert.AreEqual(orderedLightGreenPasswords[0].Category, category2);
            Assert.AreEqual(orderedLightGreenPasswords[1].Category, category);
        }

        [TestMethod]
        public void ListDarkGreenPasswordsOrderByCategory()
        {
            Category category2 = new Category("Gaming");
            Password password2 = new Password(category2, "adminADMINAdminAd.12.", site, user, note);
            Password password = new Password(category, "ADMINadminADMINad.13mi", site, user, note);
            passwordsController.AddPassword(password);
            passwordsController.AddPassword(password2);

            List<Password> orderedDarkGreenPasswords = passwordsController.ListDarkGreenPasswords();
            Assert.AreEqual(orderedDarkGreenPasswords[0].Category, category2);
            Assert.AreEqual(orderedDarkGreenPasswords[1].Category, category);
        }

        [TestMethod]
        public void GetPasswordsMatchingList()
        {
            Category category2 = new Category("Trabajo");
            Category category3 = new Category("Gaming");
            Password password2 = new Password(category2, pass, site, user, note);
            Password password3 = new Password(category3, pass, site, user, note);
            passwords.AddPassword(password);
            passwords.AddPassword(password2);
            passwords.AddPassword(password3);
            List<Password> passwords2 = new List<Password>();
            passwords2.Add(password);
            List<Password> passwordsResult = passwordsController.ListPasswordsMatching(passwords2);

            Assert.AreEqual(passwordsResult[0], password);
        }

        [TestMethod]
        public void PasswordExist()
        {
            List<Password> passList = new List<Password>();
            passList.Add(password);
            string pass = password.Pass;
            Assert.IsTrue(passwordsController.PasswordExist(passList, pass));
        }


        [TestMethod]
        public void PasswordNotExist()
        {
            List<Password> passList = new List<Password>();
            passList.Add(password);
            string pass = "dfault";
            Assert.IsTrue(passwordsController.PasswordExist(passList, pass));
        }
    }
}
