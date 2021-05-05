using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PasswordManager;

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
        string user = "root";
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
        public void AddPasswordToRepository() 
        {
            passwordRepository.AddPassword(password);
            Assert.AreEqual(passwordRepository.Count(), 1);
        }

        [TestMethod]
        public void RemovePasswordFromRepository() 
        {
            passwordRepository.AddPassword(password);
            passwordRepository.RemovePassword(password);

            Assert.AreEqual(passwordRepository.Count(), 0);
        }
    }
}
