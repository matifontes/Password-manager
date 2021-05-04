using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordManager;

namespace PasswordManagerTest
{
    [TestClass]
    public class PasswordTest
    {
        Password passwordCreatedToday;
        Password passwordCreatedYesterday;
        private Category personal;
        private string password = "admin";
        private string site = "aulas.ort.edu.uy";
        private string user = "Ralph";
        private string note = "";

        [TestInitialize]
        public void setup()
        {
            personal = new Category("Personal");
            passwordCreatedToday = new Password(personal, password, site, user, note);
            passwordCreatedYesterday = new Password(personal, password, site, user, note);
            passwordCreatedYesterday.LastModificationDate = DateTime.Today.AddDays(-1);
        }

        [TestCleanup]
        public void Cleanup()
        {
            personal = null;
            passwordCreatedToday = null;
            passwordCreatedYesterday = null;
            passwordCreatedYesterday.LastModificationDate = null;
        }

        [TestMethod]
        public void CreatePassword()
        {
            Assert.IsNotNull(passwordCreatedToday);
        }

        [TestMethod]
        public void ValidateSetPassword()
        {
            Assert.AreEqual(passwordCreatedToday.Pass, password);
        }

        [TestMethod]
        public void VerifyLastModificationDateAfterCreatingPassword() 
        {
            DateTime currentDate = DateTime.Today;
            Assert.AreEqual(passwordCreatedToday.LastModificationDate,currentDate);
        }

        [TestMethod]
        public void ValidateLastModificationDateAfterChangingPassword() 
        {
            DateTime currentDate = DateTime.Today;
            string newPassword = "tableTop5E";

            passwordCreatedYesterday.Pass = newPassword;

            Assert.AreEqual(passwordCreatedYesterday.LastModificationDate, currentDate);    
        }



    }
}