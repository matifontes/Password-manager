using System;
using PasswordManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PasswordManagerTest
{
    [TestClass]
    public class PasswordGenerationSettingsTest
    {
        const string LOWERCASE_CHARACTERS = "abcdefghijklmnopqrstuvwxyz";
        const string UPPERCASE_CHARACTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string NUMERIC_CHARACTERS = "0123456789";
        const string SPECIAL_CHARACTERS = @"!#$%&*@\";
        private GeneratePasswordSettings settingsAllTrue;
        private GeneratePasswordSettings settingsAllFalse;
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
            settingsAllTrue = new PasswordManager.GeneratePasswordSettings(passwordLength, includeLowerCase, includeUpperCase, includeNumbers, includeSpecialCharacters);
            settingsAllFalse = new PasswordManager.GeneratePasswordSettings(passwordLength, notIncludeLowerCase, notIncludeUpperCase, notIncludeNumbers, notIncludeSpecialCharacters);
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


    }
}
