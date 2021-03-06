using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordManager;
using PasswordManager.Exceptions;

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
        private string note = "nota";

        [TestInitialize]
        public void setup()
        {
            personal = new Category("Personal");
            passwordCreatedToday = new Password(personal, password, site, user, note);
            passwordCreatedYesterday = new Password(personal, password, site, user, note);
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
            Assert.AreEqual(password, passwordCreatedToday.Pass);
        }

        [TestMethod]
        public void VerifyLastModificationDateAfterCreatingPassword() 
        {
            DateTime currentDate = DateTime.Now;
            Assert.AreEqual(currentDate, passwordCreatedToday.LastModificationDate);
        }

        [TestMethod]
        public void ValidateLastModificationDateAfterChangingPassword() 
        {
            string newPassword = "tableTop5E";

            passwordCreatedYesterday.Pass = newPassword;
            DateTime currentDate = DateTime.Now;
            Assert.AreEqual(currentDate, passwordCreatedYesterday.LastModificationDate);    
        }

        [TestMethod]
        public void GetPasswordNote() 
        {
            Assert.AreEqual(note, passwordCreatedToday.Note);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPasswordUserException))]
        public void CreatePasswordWithUserLenghtLessThanFive()
        {
            string invalidUser = "Leo";
            string passTest = "TestInvalidUser";

            new Password(personal, passTest, site, invalidUser, note);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPasswordUserException))]
        public void CreatePasswordWithUserLenghtLongerThanTwentyFive()
        {
            string invalidUser = "Leo123456789123456789123456789";
            string passTest = "TestInvalidUser";

            new Password(personal, passTest, site, invalidUser, note);
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidPasswordException))]
        public void CreatePasswordWithLenghtLessThanFive()
        {
            string passTest = "1234";
            new Password(personal, passTest, site, user, note);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPasswordException))]
        public void CreatePasswordWithLenghtLongerThanTwentyFive()
        {
            string passTest = "TestInvalid123456789123456789123456789";
            new Password(personal, passTest, site, user, note);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPasswordException))]
        public void CreateEmptyPassword() 
        {
            string passTest = "      ";
            new Password(personal, passTest, site, user, note);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPasswordSiteException))]
        public void CreatePasswordSiteWithLenghtLessThanThree()
        {
            string site = "ww";
            new Password(personal, password, site, user, note);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPasswordSiteException))]
        public void CreatePasswordSiteWithLenghtLongerThanTwentyFive()
        {
            string site = "www.TestInvalid123124124124124124124.com";
            new Password(personal, password, site, user, note);
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

            new Password(personal, password, site, user, invalidNote);
        }

        [TestMethod]
        public void VerifyRedPassword()
        {
            string passR = "testR";
            Password passRed = new Password(personal, passR, site, user, note);

            Assert.AreEqual("Red", passRed.Strength);
        }

        [TestMethod]
        public void PasswordLargerThan8CharsButShorterThan15ShouldBeOrange()
        {
            string passOr = "testOrange";
            Password passOrange = new Password(personal, passOr, site, user, note);

            Assert.AreEqual("Orange", passOrange.Strength);
        }

        [TestMethod]
        public void PasswordLargerThan14WithoutMayusAndMinusShouldBeYellow() 
        {
            string passY = "1234567890111213";
            Password passYellow = new Password(personal, passY, site, user, note);

            Assert.AreEqual("Yellow", passYellow.Strength);
        }

        [TestMethod]
        public void PasswordLargerThan14WithOnlyMinusShouldBeYellow()
        {
            string passY = "testyellowyellowwwww";
            Password passYellow = new Password(personal, passY, site, user, note);

            Assert.AreEqual("Yellow", passYellow.Strength);
        }

        [TestMethod]
        public void PasswordLargerThan14WithOnlyMayusShouldBeYellow()
        {
            string passY = "TESTYELLOWTELLOWWWWW";
            Password passYellow = new Password(personal, passY, site, user, note);

            Assert.AreEqual("Yellow", passYellow.Strength );
        }

        [TestMethod]
        public void PasswordLargerThan14WithOnlyMayusAndSpecialCharsShouldBeYellow()
        {
            string passY = "TESTYELLOWTELLOWWW.WW@";
            Password passYellow = new Password(personal, passY, site, user, note);

            Assert.AreEqual("Yellow", passYellow.Strength);
        }

        [TestMethod]
        public void PasswordLargerThan14WithOnlyMayusAndNumbersShouldBeYellow()
        {
            string passY = "TESTYELLOWTELLOWWWWW231";
            Password passYellow = new Password(personal, passY, site, user, note);

            Assert.AreEqual("Yellow", passYellow.Strength);
        }

        [TestMethod]
        public void PasswordLargerThan14WithOnlyMinusAndSpecialCharsShouldBeYellow()
        {
            string passY = "testyellowyellow@wwww";
            Password passYellow = new Password(personal, passY, site, user, note);

            Assert.AreEqual("Yellow", passYellow.Strength);
        }

        [TestMethod]
        public void PasswordLargerThan14WithOnlyMinusAndNumbersShouldBeYellow()
        {
            string passY = "testyellowyelloww123www";
            Password passYellow = new Password(personal, passY, site, user, note);

            Assert.AreEqual("Yellow", passYellow.Strength);
        }

        [TestMethod]
        public void PasswordWithMayusandMinusAndLenghtLargerThen14ShouldBeLightGreen()
        {
            string passLG = "testGreenGreenGR";
            Password passLGreen = new Password(personal, passLG, site, user, note);

            Assert.AreEqual("LightGreen", passLGreen.Strength);
        }

        [TestMethod]
        public void PasswordWithLenghtLargerThen14WithMayusMinusAndSpecialSimbolsShouldBeLightGreen() 
        {
            string passLG = "test@GreenGreenGR";
            Password passLGreen = new Password(personal, passLG, site, user, note);

            Assert.AreEqual("LightGreen", passLGreen.Strength);
        }

        [TestMethod]
        public void PasswordWithLenghtLargerThen14WithMayusMinusAndNumbersShouldBeLightGreen()
        {
            string passLG = "test@GreenGreenGR";
            Password passLGreen = new Password(personal, passLG, site, user, note);

            Assert.AreEqual("LightGreen", passLGreen.Strength);
        }

        [TestMethod]
        public void PasswordLargerThan14WithMayusMinusSpecialCharsAndNumbersShouldBeDarkGreen()
        {
            string passDG = "testGreenGreen.13";
            Password passDGreen = new Password(personal, passDG, site, user, note);

            Assert.AreEqual("DarkGreen", passDGreen.Strength);
        }

        [TestMethod]
        public void PasswordToStringShowTheUser() 
        {
            Assert.AreEqual(user, passwordCreatedToday.ToString());
        }

        [TestMethod]
        public void PasswordIsEqualToAnotherPasswordIfSiteAndUserMatches() 
        {
            Password samePassword = new Password(personal,password,site,user,note);
            Assert.IsTrue(passwordCreatedToday.IsEqual(samePassword));
        }

        [TestMethod]
        public void PasswordsWithSameSiteButDifferentUserArentEqual()
        {
            string user = "Primo";
            Password samePassword = new Password(personal, password, site, user, note);
            Assert.IsFalse(passwordCreatedToday.Equals(samePassword));
        }

        [TestMethod]
        public void PasswordsWithSameUserButDifferentSiteArentEqual()
        {
            string site = "steam";
            Password samePassword = new Password(personal, password, site, user, note);
            Assert.IsFalse(passwordCreatedToday.Equals(samePassword));
        }

        [TestMethod]
        public void VerifyPasswordId()
        {
            passwordCreatedToday.Id = 1;

            Assert.AreEqual(1, passwordCreatedToday.Id);
        }

    }
}