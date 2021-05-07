﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordManager;
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
