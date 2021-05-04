using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PasswordManagerTest
{
    [TestClass]
    public class ProfileControllerTest
    {
        [TestMethod]
        public void CreateProfileWithPassword()
        {
            string password = "1234Hi@";
            ProfileController profileController = new ProfileController(password);
            Assert.IsTrue(profileController.ValidatePassword(password));
        }

        public void ValidateWithWrongPassword() 
        {
            string password = "1234Hi@";
            string wrongPassword = "1234";
            ProfileControllerTest profileController = new ProfileController(password);
            Assert.IsFalse(profileController.ValidateWithWrongPassword(wrongPassword));
        }
    }
}
