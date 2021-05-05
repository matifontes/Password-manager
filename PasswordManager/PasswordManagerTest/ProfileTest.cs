using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PasswordManager;

namespace PasswordManagerTest
{
    [TestClass]
    public class ProfileTest
    {
        private Profile systemProfile;
        private Profile systemProfileWithSpecialCharactersOnPassword;
        private string validPassword = "admin";
        private string specialCharacterPsw = "3123#@@12";
        private Category category;

        [TestInitialize]
        public void Setup()
        {
            systemProfile = new PasswordManager.Profile(validPassword);
            systemProfileWithSpecialCharactersOnPassword = new PasswordManager.Profile(specialCharacterPsw);
            category = new Category("Work");
        }

        [TestCleanup]
        public void Cleanup() 
        {
            systemProfile = null;
            systemProfileWithSpecialCharactersOnPassword = null;
            category = null;
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
            Assert.IsTrue(systemProfile.ValidateSystemPassword(validPassword));
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

            Assert.IsFalse(systemProfile.ValidateSystemPassword(invalidPassword));
        }

        [TestMethod]
        public void LoginHavingAPasswordWithSpecialSimbols() 
        {
            Assert.IsTrue(systemProfileWithSpecialCharactersOnPassword.ValidateSystemPassword(specialCharacterPsw));       
        }

        [TestMethod]
        public void ChangePassword()
        {
            string newPassword = "test123";
            systemProfile.ChangePassword(validPassword, newPassword);
            Assert.IsTrue(systemProfile.ValidateSystemPassword(newPassword));
        }

        [TestMethod]
        public void ChangePasswordUsingInvalidAcutalPassword()
        {
            string newPassword = "test123";
            string invalidActualPassword = "adm123";
            systemProfile.ChangePassword(invalidActualPassword, newPassword);
            Assert.IsFalse(systemProfile.ValidateSystemPassword(newPassword));
        }

    }
}
