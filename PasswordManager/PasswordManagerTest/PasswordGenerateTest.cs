using System;
using PasswordManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PasswordManagerTest
{
    [TestClass]
    public class PasswordGenerateTest
    {
        private GeneratePasswordSettings settingsAllTrue;
        private GeneratePasswordSettings settingsMmNS;
        private int passwordLength = 10;
        private bool includeLowerCase = true;
        private bool includeUpperCase = true;
        private bool includeUpperCaseFalse = false;
        private bool includeNumbers = true;
        private bool includeSpecialCharacters = true;

        [TestInitialize]
        public void Setup()
        {
            settingsAllTrue = new GeneratePasswordSettings(passwordLength, includeLowerCase, includeUpperCase, includeNumbers, includeSpecialCharacters);
            settingsMmNS = new GeneratePasswordSettings(passwordLength, includeLowerCase, includeUpperCaseFalse, includeNumbers, includeSpecialCharacters);
        }

        [TestMethod]
        public void GeneratePassword()
        {
            string password = PasswordGenerator.GeneratePassword(settingsAllTrue);
            Assert.IsNotNull(password);
        }

        [TestMethod]
        public void VerifyPasswordGeneratedLength()
        {
            string password = PasswordGenerator.GeneratePassword(settingsAllTrue);
            Assert.AreEqual(password.Length, settingsAllTrue.PasswordLength);
        }

        [TestMethod]
        public void ValidPasswordVerify()
        {
            string passMMNS = "MjLqr1.";
            Assert.IsTrue(PasswordGenerator.PasswordIsValid(settingsAllTrue, passMMNS));
        }
        [TestMethod]
        public void InvalidPasswordVerify()
        {
            string passMMnS = "MjLqr.";
            Assert.IsFalse(PasswordGenerator.PasswordIsValid(settingsAllTrue, passMMnS));
        }

        [TestMethod]
        public void CheckIfAllTruePasswordGeneratedIsValid()
        {
            string password = PasswordGenerator.GeneratePassword(settingsAllTrue);
            Assert.IsTrue(PasswordGenerator.PasswordIsValid(settingsAllTrue, password));
        }

        [TestMethod]
        public void CheckIfNotAllTruePasswordGeneratedIsValid()
        {
            string password = PasswordGenerator.GeneratePassword(settingsMmNS);
            Assert.IsTrue(PasswordGenerator.PasswordIsValid(settingsMmNS, password));
        }
    }
}
