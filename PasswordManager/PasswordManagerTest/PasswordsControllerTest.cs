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
        [ExpectedException(typeof(PasswordAlreadyExistsException))]
        public void AddPasswordThatAlreadyExitsThrowsException()
        {
            passwordsController.AddPassword(password);
            passwordsController.AddPassword(password);
        }

        [TestMethod]
        [ExpectedException(typeof(PasswordAlreadyExistsException))]
        public void AddPasswordWithSameUserAndSiteThenOtherPasswordThrowsAlreadyExistsException()
        {
            passwordsController.AddPassword(password);
            string pass = "rootpassword";
            string note = "password";
            Password samePassword = new Password(category, pass, site, user, note);
            passwordsController.AddPassword(samePassword);
        }

        [TestMethod]
        public void ControllerContainsPasswordAddedToIt()
        {
            passwordsController.AddPassword(password);
            Assert.IsTrue(passwordsController.ContainsPassword(password));
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
            string userForPassword2 = "Ramon";
            string userForPassword3 = "Guest";
            Password password2 = new Password(category2, pass, site, userForPassword2, note);
            Password password3 = new Password(category3, pass, site, userForPassword3, note);
            passwordsController.AddPassword(password);
            passwordsController.AddPassword(password2);
            passwordsController.AddPassword(password3);

            List<Password> orderedPassword = passwordsController.ListPasswords();
            Assert.AreEqual(category3, orderedPassword[0].Category);
            Assert.AreEqual(category, orderedPassword[1].Category);
            Assert.AreEqual(category2, orderedPassword[2].Category);
        }

        [TestMethod]
        public void ListRedPasswordsOrderByCategory()
        {
            Password password1 = new Password(category, "guest", site, user, note);
            Category category2 = new Category("Gaming");
            string userForPassword2 = "Guest";
            Password password2 = new Password(category2, pass, site, userForPassword2, note);
            passwordsController.AddPassword(password1);
            passwordsController.AddPassword(password2);

            List<Password> orderedRedPasswords = passwordsController.ListRedPasswords();
            Assert.AreEqual(category2, orderedRedPasswords[0].Category);
            Assert.AreEqual(category, orderedRedPasswords[1].Category);
        }

        [TestMethod]
        public void ListOrangePasswordsOrderByCategory()
        {
            Password password1 = new Password(category, "adminadmin", site, user, note);
            Category category2 = new Category("Gaming");
            string userForPassword2 = "Guest";
            string passForPassword2 = "gfdghggfhjf";
            Password password2 = new Password(category2, passForPassword2, site, userForPassword2, note);
            passwordsController.AddPassword(password1);
            passwordsController.AddPassword(password2);

            List<Password> orderedOrangePasswords = passwordsController.ListOrangePasswords();
            Assert.AreEqual(category2, orderedOrangePasswords[0].Category);
            Assert.AreEqual(category, orderedOrangePasswords[1].Category);
        }

        [TestMethod]
        public void ListYellowPasswordsOrderByCategory()
        {
            Password password = new Password(category, "ADMINADMINADMINADMIN", site, user, note);
            Category category2 = new Category("Gaming");
            string userForPassword2 = "Guest";
            string passForPassword2 = "adminadminadmin";
            Password password2 = new Password(category2, passForPassword2, site, userForPassword2, note);
            passwordsController.AddPassword(password);
            passwordsController.AddPassword(password2);

            List<Password> orderedYellowPasswords = passwordsController.ListYellowPasswords();
            Assert.AreEqual(category2, orderedYellowPasswords[0].Category);
            Assert.AreEqual(category, orderedYellowPasswords[1].Category);
        }

        [TestMethod]
        public void ListLightGreenPasswordsOrderByCategory()
        {
            Category category2 = new Category("Gaming");
            string userForPassword2 = "Guest";
            string passForPassword2 = "userUSERuserUser";
            Password password2 = new Password(category2, passForPassword2, site, userForPassword2, note);
            Password password = new Password(category, "ADMINadminADMINadminAD", site, user, note);
            passwordsController.AddPassword(password);
            passwordsController.AddPassword(password2);

            List<Password> orderedLightGreenPasswords = passwordsController.ListLightGreenPasswords();
            Assert.AreEqual(category2, orderedLightGreenPasswords[0].Category);
            Assert.AreEqual(category, orderedLightGreenPasswords[1].Category);
        }

        [TestMethod]
        public void ListDarkGreenPasswordsOrderByCategory()
        {
            Category category2 = new Category("Gaming");
            string userForPassword2 = "Guest";
            string passForPassword2 = "userUSERuserUser123@";
            Password password2 = new Password(category2, passForPassword2, site, userForPassword2, note);
            Password password = new Password(category, "ADMINadminADMINad.13mi", site, user, note);
            passwordsController.AddPassword(password);
            passwordsController.AddPassword(password2);

            List<Password> orderedDarkGreenPasswords = passwordsController.ListDarkGreenPasswords();
            Assert.AreEqual(category2, orderedDarkGreenPasswords[0].Category);
            Assert.AreEqual(category, orderedDarkGreenPasswords[1].Category);
        }

        [TestMethod]
        public void GetPasswordsMatchingList()
        {
            Category category2 = new Category("Trabajo");
            Category category3 = new Category("Gaming");
            string userForPassword2 = "Miguel";
            string userForPassword3 = "Guest";
            Password password2 = new Password(category2, pass, site, userForPassword2, note);
            Password password3 = new Password(category3, pass, site, userForPassword3, note);
            passwords.AddPassword(password);
            passwords.AddPassword(password2);
            passwords.AddPassword(password3);
            List<Password> passwords2 = new List<Password>();
            passwords2.Add(password);
            List<Password> passwordsResult = passwordsController.ListPasswordsMatching(passwords2);

            Assert.AreEqual(passwordsResult[0], password);
        }

    }
}
