using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PasswordManager;

namespace PasswordManagerTest
{
    [TestClass]
    public class ProfileTest
    {
        private Profile profile;
        private Profile profileWithSpecialCharactersOnPassword;
        private string validPassword = "admin";
        private string specialCharacterPsw = "3123#@@12";

        [TestInitialize]
        public void Setup()
        {
            profile = new PasswordManager.Profile(validPassword);
            profileWithSpecialCharactersOnPassword = new PasswordManager.Profile(specialCharacterPsw);
        }

        [TestCleanup]
        public void Cleanup() 
        {
            profile = null;
            profileWithSpecialCharactersOnPassword = null;
        }

        [TestMethod]
        public void CreateUser()
        {
            Assert.IsNotNull(profile);
        }

        [TestMethod]
        public void ValidatePasswordParameterOnUserCreation()
        {
            Assert.AreEqual(profile.password, validPassword);
        }

        [TestMethod]
        public void CreateUserWithAPasswordUsingSpecialCharacters() 
        {
            Assert.AreEqual(profileWithSpecialCharactersOnPassword.password, specialCharacterPsw);
        }

        [TestMethod]
        public void LoginWithValidPassword()
        {
            Assert.IsTrue(profile.ValidateSystemPassword(validPassword));
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

            Assert.IsFalse(profile.ValidateSystemPassword(invalidPassword));
        }

        [TestMethod]
        public void LoginHavingAPasswordWithSpecialSimbols() 
        {
            Assert.IsTrue(profileWithSpecialCharactersOnPassword.ValidateSystemPassword(specialCharacterPsw));       
        }

        [TestMethod]
        public void ChangePassword()
        {
            string newPassword = "test123";
            profile.ChangePassword(validPassword, newPassword);
            Assert.IsTrue(profile.ValidateSystemPassword(newPassword));
        }

        [TestMethod]
        [ExpectedException(typeof(FailToValidatePasswordException))] 
        public void ChangePasswordUsingInvalidAcutalPasswordThrowsException()
        {
            string newPassword = "test123";
            string invalidActualPassword = "adm123";
            profile.ChangePassword(invalidActualPassword, newPassword);
        }

    }
}
