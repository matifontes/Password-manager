using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PasswordManager;
using System.Collections.Generic;

namespace PasswordManagerTest
{
    [TestClass]
    public class PasswordRepositoryTest
    {
        private PasswordRepository passwordRepository;
        private Category category;
        private Password password;
        private string categoryName = "Personal";
        private string pass = "Admin";
        string site = "site";
        string user = "Admin";
        string note = "note";

        [TestInitialize]
        public void Setup() 
        {
            category = new Category(categoryName);
            password = new Password(category,pass,site,user,note);
            passwordRepository = new PasswordRepository();
        }

        [TestCleanup]
        public void Cleanup() 
        {
            category = null;
            password = null;
            passwordRepository = null;
        }

        [TestMethod]
        public void CreatePasswordsRepository()
        {
            Assert.IsNotNull(passwordRepository);
        }

        [TestMethod]
        public void CreateNewPasswordsRepositoryShouldBeEmpty() 
        {
            Assert.IsTrue(passwordRepository.IsEmpty());
        }

        [TestMethod]
        public void AddPasswordToRepository() 
        {
            passwordRepository.AddPassword(password);
            Assert.AreEqual(passwordRepository.Count(), 1);
        }

        [TestMethod]
        public void PasswordRepositoryWithAPasswordShouldntBeEmpty()
        {
            passwordRepository.AddPassword(password);
            Assert.IsFalse(passwordRepository.IsEmpty());
        }

        [TestMethod]
        public void RemovePasswordFromRepository() 
        {
            passwordRepository.AddPassword(password);
            passwordRepository.RemovePassword(password);

            Assert.AreEqual(passwordRepository.Count(), 0);
        }

        [TestMethod]
        public void ListPasswordsOrderByCategory() 
        {
            Category category2 = new Category("Trabajo");
            Category category3 = new Category("Gaming");
            Password password2 = new Password(category2, pass, site, user, note);
            Password password3 = new Password(category3, pass, site, user, note);
            passwordRepository.AddPassword(password);
            passwordRepository.AddPassword(password2);
            passwordRepository.AddPassword(password3);

            List<Password> orderedPassword = passwordRepository.ListPasswords();
            Assert.AreEqual(orderedPassword[0].Category, category3);
            Assert.AreEqual(orderedPassword[1].Category, category);
            Assert.AreEqual(orderedPassword[2].Category, category2);
        }

        [TestMethod]
        public void ListPasswordsStrengthOrderByCategory()
        {
            Category category2 = new Category("Trabajo");
            Category category3 = new Category("Gaming");
            Password password2 = new Password(category2, pass, site, user, note);
            Password password3 = new Password(category3, pass, site, user, note);
            List<Password> passwords = passwordRepository.ListPasswords();
            passwords.Add(password);
            passwords.Add(password2);
            passwords.Add(password3);
            List<Password> orderedPassword= passwordRepository.SortListByCategoryName(passwords);

            Assert.AreEqual(orderedPassword[0].Category, category3);
            Assert.AreEqual(orderedPassword[1].Category, category);
            Assert.AreEqual(orderedPassword[2].Category, category2);
        }

        [TestMethod]
        public void ListPasswordsRedStrength()
        {
            passwordRepository.AddPassword(password);
            List<Password> redPasswords = passwordRepository.ListRedPasswords();
            Assert.IsFalse(passwordRepository.IsEmptyList(redPasswords));
        }

        [TestMethod]
        public void ListPasswordsOrangeStrength()
        {
            string passOr = "testOrange";
            Password passOrange = new Password(category, passOr, site, user, note);
            passwordRepository.AddPassword(passOrange);
            List<Password> orangePasswords = passwordRepository.ListOrangePasswords();
            Assert.IsFalse(passwordRepository.IsEmptyList(orangePasswords));
        }

        [TestMethod]
        public void ListPasswordsYellowStrength()
        {
            string passY = "testyellowyellowwwww";
            Password passYellow = new Password(category, passY, site, user, note);
            passwordRepository.AddPassword(passYellow);
            List<Password> yellowPasswords = passwordRepository.ListYellowPasswords();
            Assert.IsFalse(passwordRepository.IsEmptyList(yellowPasswords));
        }

        [TestMethod]
        public void ListPasswordsLightGreenStrength()
        {
            string passLG = "testGreenGreenGR";
            Password passLGreen = new Password(category, passLG, site, user, note);
            passwordRepository.AddPassword(passLGreen);
            List<Password> lGreenPasswords = passwordRepository.ListLGreenPasswords();
            Assert.IsFalse(passwordRepository.IsEmptyList(lGreenPasswords));
        }

        [TestMethod]
        public void ListPasswordsDarkGreenStrength()
        {
            string passDG = "testGreenGreen.13";
            Password passDGreen = new Password(category, passDG, site, user, note);
            passwordRepository.AddPassword(passDGreen);
            List<Password> dGreenPasswords = passwordRepository.ListDGreenPasswords();
            Assert.IsFalse(passwordRepository.IsEmptyList(dGreenPasswords));
        }
    }
}
