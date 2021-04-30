using System;
using PasswordManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PasswordManagerTest
{
    [TestClass]
    public class PasswordGenerateTest
    {
        private GeneratePasswordSettings settingsAllTrue;
        int passwordLength = 10;
        bool includeLowerCase = true;
        bool includeUpperCase = true;
        bool includeNumbers = true;
        bool includeSpecialCharacters = true;

        [TestInitialize]
        public void Setup()
        {
            settingsAllTrue = new GeneratePasswordSettings(passwordLength, includeLowerCase, includeUpperCase, includeNumbers, includeSpecialCharacters);
        }

        [TestMethod]
        public void GeneratePassword()
        {
            string password = PasswordGenerator.GeneratePassword(settingsAllTrue);
            Assert.IsNotNull(password);
        }

    }
}
