using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordManager.Controllers;
using PasswordManager.Exceptions;
using System;
using PasswordManager;

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
        public void CreateControllerWithProfile() 
        {
            Profile profile = new Profile("TESTS");
            ProfileController profileController = new ProfileController(profile);
            Assert.AreEqual(profile,profileController.GetProfile());
        }

        [TestMethod]
        public void GetProfileId() 
        {
            profileController.GetProfile().Id = 1;
            Assert.AreEqual(1, profileController.GetId());
        }

        [TestMethod]
        public void GetProfileCreated()
        {
            Assert.IsNotNull(profileController.GetProfile());
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
    }
}
