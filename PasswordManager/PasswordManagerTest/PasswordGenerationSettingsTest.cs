using System;
using PasswordManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PasswordManagerTest
{
    [TestClass]
    public class PasswordGenerationSettingsTest
    {
        [TestMethod]
        public void GeneratePasswordSettings()
        {
            int passwordLength = 10;
            bool includeLowerCase = true;
            bool includeUpperCase = true;
            bool includeNumbers = true;
            bool includeSpecialCharacters = true;
            GeneratePasswordSettings settings = new GeneratePasswordSettings(passwordLength, includeLowerCase, includeUpperCase, includeNumbers, includeSpecialCharacters);
            Assert.IsNotNull(settings);
        }
    }
}
