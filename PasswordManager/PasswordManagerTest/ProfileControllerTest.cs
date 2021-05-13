using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordManager.Controllers;
using PasswordManager.Exceptions;
using System;

namespace PasswordManagerTest
{
    [TestClass]
    public class ProfileControllerTest
    {
        private string password = "1234Hi@";
        private ProfileController profileController;

        [TestInitialize]
        public void Setup() 
        {
            profileController = new ProfileController(password);
        }

        [TestCleanup]
        public void Cleanup() 
        {
            profileController = null;
        }

        [TestMethod]
        public void CreateProfileWithPassword()
        {
            Assert.IsTrue(profileController.ValidatePassword(password));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPasswordException))]
        public void InValidPassworLenghtLongerThen25OnUserCreation()
        {
            string invalidPassowrd = "1234567890ABCDEFGHTYUGFASDFDD";
            ProfileController profile = new ProfileController(invalidPassowrd);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPasswordException))]
        public void InValidPassworLenghtShorterThen5OnUserCreation()
        {
            string invalidPassowrd = "1234";
            ProfileController profile = new ProfileController(invalidPassowrd);
        }

        [TestMethod]
        public void ValidateWithWrongPassword() 
        {
            string wrongPassword = "1234";
            Assert.IsFalse(profileController.ValidatePassword(wrongPassword));
        }

        [TestMethod]
        public void ChangePasswordOfAProfile() 
        {
            string newpassword = "Barto@1234";
            profileController.ChangePassword(password, newpassword);
            Assert.IsTrue(profileController.ValidatePassword(newpassword));
        }

        [TestMethod]
        [ExpectedException(typeof(FailToValidatePasswordException))]
        public void ChangePasswordOfAProfileUsingWrongActualPassword() 
        {
            string invalidActualPassword = "1234";
            string newpassword = "Barto@1234";

            profileController.ChangePassword(invalidActualPassword, newpassword);
        }

        [TestMethod]
        public void GetCategoryRepository() 
        {
            Assert.IsNotNull(profileController.GetCategoryRepository());
        }

        [TestMethod]
        public void GetPasswordRepository()
        {
            Assert.IsNotNull(profileController.GetPasswordRepository());
        }

        [TestMethod]
        public void GetCreditCardRepository()
        {
            Assert.IsNotNull(profileController.GetCreditCardRepository());
        }
    }
}
