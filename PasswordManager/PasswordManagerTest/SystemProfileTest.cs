using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PasswordManager;

namespace PasswordManagerTest
{
    [TestClass]
    public class SystemProfileTest
    {
        private SystemProfile systemProfile;
        private SystemProfile systemProfileWithSpecialCharactersOnPassword;
        private string validPassword = "admin";
        private string specialCharacterPsw = "3123#@@12";

        [TestInitialize]
        public void Setup()
        {
            systemProfile = new PasswordManager.SystemProfile(validPassword);
            systemProfileWithSpecialCharactersOnPassword = new PasswordManager.SystemProfile(specialCharacterPsw);
        }

        [TestCleanup]
        public void Cleanup() 
        {
            systemProfile = null;
            systemProfileWithSpecialCharactersOnPassword = null;
        }

        [TestMethod]
        public void CreateUser()
        {
            Assert.IsNotNull(systemProfile);
        }

        [TestMethod]
        public void ValidatePasswordParameterOnUserCreation()
        {
            Assert.AreEqual(systemProfile.SystemPassword, validPassword);
        }

        [TestMethod]
        public void CreateUserWithAPasswordUsingSpecialCharacters() 
        {
            Assert.AreEqual(systemProfileWithSpecialCharactersOnPassword.SystemPassword, specialCharacterPsw);
        }

        [TestMethod]
        public void LoginWithValidPassword()
        {
            Assert.IsTrue(systemProfile.Login(validPassword));
        }

        [TestMethod]
        public void LoginWithIncorrectPassword() 
        {
            string invalidPassword = "";
            const int STRING_LENGHT = 12;

            for (int count = 0; count <= STRING_LENGHT; count++) 
            {
                invalidPassword += "A";
            }

            Assert.IsFalse(systemProfile.Login(invalidPassword));
        }

        [TestMethod]
        public void LoginHavingAPasswordWithSpecialSimbols() 
        {
            Assert.IsTrue(systemProfileWithSpecialCharactersOnPassword.Login(specialCharacterPsw));       
        }

        [TestMethod]
        public void AddedNewCategoryExists() 
        {
            string categoryName = "Work";
            Category category = new Category(categoryName);
            systemProfile.AddCategory(category);
            bool wasAdded = systemProfile.CategoryExists(category);
            Assert.IsTrue(wasAdded);
        }

        [TestMethod]
        public void CategoryThatWasntAddedDoesNotExists() 
        {
            Category categoryThatDoesntExists = new Category("Work");
            Assert.IsFalse(systemProfile.CategoryExists(categoryThatDoesntExists));
        }
        [TestMethod]
        public void AddedNewPasswordExists()
        {
            Category category = new Category("Work");
            string pass = "admin";
            string site = "aulas.ort.edu.uy";
            string user = "Ralph";
            string note = "";
            Password password = new Password(category, pass, site, user, note);
            systemProfile.AddPassword(password);
        }

    }
}
