using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PasswordManager;

namespace PasswordManagerTest
{
    [TestClass]
    public class PasswordRepositoryTest
    {
        [TestMethod]
        public void CreatePasswordsRepository()
        {
            PasswordRepository passwordRepository = new PasswordRepository();
            Assert.IsNotNull(passwordRepository);
        }

        [TestMethod]
        public void AddPasswordToRepository() 
        {
            PasswordRepository passwordRepository = new PasswordRepository();
            string categorie = "Trabajo";
            string pass = "Admin";
            string site = "site";
            string user = "root";
            string note = "Note";
            Category category = new Category(categorie);
            Password password = new Password(category,pass,site,user,note);

            passwordRepository.AddPassword(password);

            Assert.AreEqual(passwordRepository.Count(), 1);
        }

        [TestMethod]
        public void RemovePasswordFromRepository() 
        {
            PasswordRepository passwordRepository = new PasswordRepository();
            string categorie = "Trabajo";
            string pass = "Admin";
            string site = "site";
            string user = "root";
            string note = "Note";
            Category category = new Category(categorie);
            Password password = new Password(category, pass, site, user, note);

            passwordRepository.AddPassword(password);

            passwordRepository.RemovePassword(password);

            Assert.AreEqual(passwordRepository.Count(), 0);
        }
    }
}
