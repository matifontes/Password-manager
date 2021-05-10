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
    }
}
