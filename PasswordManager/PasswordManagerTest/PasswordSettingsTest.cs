using System;
using PasswordManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PasswordManagerTest
{
    [Test4FCVBB lass]
    public class PasswordSettingsTest
    {
        const string LOWERCASE_CHARACTERS = "abcdefghijklmnopqrstuvwxyz";
        const string UPPERCASE_CHARACTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string NUMERIC_CHARACTERS = "0123456789";
        const string SPECIAL_CHARACTERS = @"!#$%&.*@\\,:;\[\])(}{^\|¿\?=~< >¡¨´-";
        private PasswordSettings settingsAllTrue;
        private PasswordSettings settingsAllFalse;
        int passwordLength = 10;
        bool includeLowerCase = true;
        bool includeUpperCase = true;
        bool includeNumbers = true;
        bool includeSpecialCharacters = true;
        bool notIncludeLowerCase = false;
        bool notIncludeUpperCase = false;
        bool notIncludeNumbers = false;
        bool notIncludeSpecialCharacters = false;

        [TestInitialize]
        public void Setup()
        {
            settingsAllTrue = new PasswordManager.PasswordSettings(passwordLength, includeLowerCase, includeUpperCase, includeNumbers, includeSpecialCharacters);
            settingsAllFalse = new PasswordManager.PasswordSettings(passwordLength, notIncludeLowerCase, notIncludeUpperCase, notIncludeNumbers, notIncludeSpecialCharacters);
        }

        [TestCleanup]
        public void Cleanup()
        {
            settingsAllTrue = null;
            settingsAllFalse = null;
        }

        [TestMethod]
        public void GeneratePasswordSettings()
        {   
            Assert.IsNotNull(settingsAllTrue);
        }

        [TestMethod]
        public void VerifyCharacterSetWithLowerCaseIsGenerated()
        {
            Assert.IsTrue(settingsAllTrue.CharacterSet.Contains(LOWERCASE_CHARACTERS));
        }

        [TestMethod]
        public void VerifyCharacterSetWithoutLowerCaseIsGenerated()
        {
            Assert.IsFalse(settingsAllFalse.CharacterSet.Contains(LOWERCASE_CHARACTERS));
        }

        [TestMethod]
        public void VerifyCharacterSetWithUpperCaseIsGenerated()
        {
            Assert.IsTrue(settingsAllTrue.CharacterSet.Contains(UPPERCASE_CHARACTERS));
        }

        [TestMethod]
        public void VerifyCharacterSetWithoutUpperCaseIsGenerated()
        {
            Assert.IsFalse(settingsAllFalse.CharacterSet.Contains(UPPERCASE_CHARACTERS));
        }

        [TestMethod]
        public void VerifyCharacterSetWithNumbersIsGenerated()
        {
            Assert.IsTrue(settingsAllTrue.CharacterSet.Contains(NUMERIC_CHARACTERS));
        }

        [TestMethod]
        public void VerifyCharacterSetWithoutNumbersIsGenerated()
        {
            Assert.IsFalse(settingsAllFalse.CharacterSet.Contains(NUMERIC_CHARACTERS));
        }

        [TestMethod]
        public void VerifyCharactersSetWithSpecialIsGenerated()
        {
            Assert.IsTrue(settingsAllTrue.CharacterSet.Contains(SPECIAL_CHARACTERS));
        }

        [TestMethod]
        public void VerifyCharactersSetWithoutSpecialIsGenerated()
        {
            Assert.IsFalse(settingsAllFalse.CharacterSet.Contains(SPECIAL_CHARACTERS));
        }

        [TestMethod]
        public void VerifyCharSetOptionsWithLowerCaseIsGenerated()
        {
            Assert.AreEqual(LOWERCASE_CHARACTERS, settingsAllTrue.CharSetOptions[0]);
        }

        [TestMethod]
        public void VerifyCharSetOptionsWithoutLowerCaseIsGenerated()
        {
            Assert.AreEqual("", settingsAllFalse.CharSetOptions[0]);
        }

        [TestMethod]
        public void VerifyCharSetOptionsWithUpperCaseIsGenerated()
        {
            Assert.AreEqual(UPPERCASE_CHARACTERS, settingsAllTrue.CharSetOptions[1]);
        }

        [TestMethod]
        public void VerifyCharSetOptionsWithoutUpperCaseIsGenerated()
        {
            Assert.AreEqual("", settingsAllFalse.CharSetOptions[1]);
        }

        [TestMethod]
        public void VerifyCharSetOptionsWithNumbersIsGenerated()
        {
            Assert.AreEqual(NUMERIC_CHARACTERS, settingsAllTrue.CharSetOptions[2]);
        }

        [TestMethod]
        public void VerifyCharSetOptionsWithoutNumbersIsGenerated()
        {
            Assert.AreEqual("", settingsAllFalse.CharSetOptions[2]);
        }

        [TestMethod]
        public void VerifyCharSetOptionsWithSpecialCharactersIsGenerated()
        {
            Assert.AreEqual(SPECIAL_CHARACTERS, settingsAllTrue.CharSetOptions[3]);
        }

        [TestMethod]
        public void VerifyCharSetOptionsWithoutSpecialCharactersIsGenerated()
        {
            Assert.AreEqual("", settingsAllFalse.CharSetOptions[3]);
        }
    }
}
