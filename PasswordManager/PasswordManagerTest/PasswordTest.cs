using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordManager;
using PasswordManager.Exceptions;

namespace PasswordManagerTest
{
    [TestClass]
    public class PasswordTest
    {
        Profile profile;
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
            profile = new Profile("test123");
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
        }

        [TestMethod]
        public void CreatePasswordWithStringPassword()
        {
            string passTest = "134151";
            Password pass = new Password(passTest);
            
            Assert.IsNotNull(pass);
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

        [TestMethod]
        [ExpectedException(typeof(InvalidPasswordUserException))]
        public void CreatePasswordWithUserLenghtLessThanFive()
        {
            string invalidUser = "Leo";
            string passTest = "TestInvalidUser";

            Password passInvalid = new Password(personal, passTest, site, invalidUser, note);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPasswordUserException))]
        public void CreatePasswordWithUserLenghtLongerThanTwentyFive()
        {
            string invalidUser = "Leo123456789123456789123456789";
            string passTest = "TestInvalidUser";

            Password passInvalid = new Password(personal, passTest, site, invalidUser, note);
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidPasswordException))]
        public void CreatePasswordWithLenghtLessThanFive()
        {
            string passTest = "1234";
            Password passInvalid = new Password(personal, passTest, site, user, note);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPasswordException))]
        public void CreatePasswordWithLenghtLongerThanTwentyFive()
        {
            string passTest = "TestInvalid123456789123456789123456789";
            Password passInvalid = new Password(personal, passTest, site, user, note);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPasswordSiteException))]
        public void CreatePasswordSiteWithLenghtLessThanThree()
        {
            string site = "ww";
            Password passInvalid = new Password(personal, password, site, user, note);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPasswordSiteException))]
        public void CreatePasswordSiteWithLenghtLongerThanTwentyFive()
        {
            string site = "www.TestInvalid123124124124124124124.com";
            Password passInvalid = new Password(personal, password, site, user, note);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPasswordNoteException))]
        public void CreatePasswordNoteWithLenghtLongerThanTwoHundredFiftyFive()
        {
            string invalidNote = "";
            for(int i =0; i < 260; i++)
            {
                invalidNote += "a";
            }

            Password passInvalid = new Password(personal, password, site, user, invalidNote);
        }

        [TestMethod]
        public void VerifyRedPassword()
        {
            string passR = "testR";
            Password passRed = new Password(personal, passR, site, user, note);

            Assert.AreEqual(passRed.Strength, "Red");
        }

        [TestMethod]
        public void VerifyOrangePassword()
        {
            string passOr = "testOrange";
            Password passOrange = new Password(personal, passOr, site, user, note);

            Assert.AreEqual(passOrange.Strength, "Orange");
        }

        [TestMethod]
        public void VerifyYellowPassword()
        {
            string passY = "testyellowyellowwwww";
            Password passYellow = new Password(personal, passY, site, user, note);

            Assert.AreEqual(passYellow.Strength, "Yellow");
        }

        [TestMethod]
        public void VeifyLightGreenPassword()
        {
            string passLG = "testGreenGreenGR";
            Password passLGreen = new Password(personal, passLG, site, user, note);

            Assert.AreEqual(passLGreen.Strength, "LightGreen");
        }

        [TestMethod]
        public void VeifyDarkGreenPassword()
        {
            string passDG = "testGreenGreen.13";
            Password passDGreen = new Password(personal, passDG, site, user, note);

            Assert.AreEqual(passDGreen.Strength, "DarkGreen");
        }

        [TestMethod]
        public void PasswordToStringShowTheUser() 
        {
            Assert.AreEqual(passwordCreatedToday.ToString(), user);
        }

    }
}