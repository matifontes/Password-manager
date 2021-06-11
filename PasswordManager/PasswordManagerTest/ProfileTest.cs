using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PasswordManager;
using PasswordManager.Exceptions;

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
            Assert.AreEqual(profile.Password, validPassword);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPasswordException))]
        public void InValidPassworLenghtLongerThen25OnProfileCreation() 
        {
            string invalidPassowrd = "1234567890ABCDEFGHTYUGFASDFDD";
            Profile profile = new PasswordManager.Profile(invalidPassowrd);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPasswordException))]
        public void InValidPassworLenghtShorterThen5OnProfileCreation()
        {
            string invalidPassowrd = "1234";
            Profile profile = new PasswordManager.Profile(invalidPassowrd);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPasswordException))]
        public void EmptyPasswordOnProfileCreation() 
        {
            string invalidPassowrd = "      ";
            Profile profile = new PasswordManager.Profile(invalidPassowrd);
        }

        [TestMethod]
        public void CreateUserWithAPasswordUsingSpecialCharacters() 
        {
            Assert.AreEqual(profileWithSpecialCharactersOnPassword.Password, specialCharacterPsw);
        }

        [TestMethod]
        public void LoginWithValidPassword()
        {
            Assert.IsTrue(profile.ValidatePassword(validPassword));
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

            Assert.IsFalse(profile.ValidatePassword(invalidPassword));
        }

        [TestMethod]
        public void LoginHavingAPasswordWithSpecialSimbols() 
        {
            Assert.IsTrue(profileWithSpecialCharactersOnPassword.ValidatePassword(specialCharacterPsw));       
        }

        [TestMethod]
        public void ChangePassword()
        {
            string newPassword = "test123";
            profile.ChangePassword(validPassword, newPassword);
            Assert.IsTrue(profile.ValidatePassword(newPassword));
        }

        [TestMethod]
        [ExpectedException(typeof(FailToValidatePasswordException))] 
        public void ChangePasswordUsingInvalidAcutalPasswordThrowsException()
        {
            string newPassword = "test123";
            string invalidActualPassword = "adm123";
            profile.ChangePassword(invalidActualPassword, newPassword);
        }

        [TestMethod]
        public void CreateProfileIntilizeAnEmptyCategoryRepository() 
        {
            Assert.IsNotNull(profile.GetCategoryRepository());
        }

        [TestMethod]
        public void CreateProfileIntilizeAnEmptyPasswordRepository()
        {
            Assert.IsNotNull(profile.GetPasswordRepository());
        }

        [TestMethod]
        public void CreateProfileIntilizeAnEmptyCreditCardRepository()
        {
            Assert.IsNotNull(profile.GetCreditCardRepository());
        }

    }
}
