using System;
using PasswordManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PasswordManagerTest
{
    [TestClass]
    public class PasswordGenerationSettingsTest
    {
        private GeneratePasswordSettings settings;
        int passwordLength = 10;
        bool includeLowerCase = true;
        bool includeUpperCase = true;
        bool includeNumbers = true;
        bool includeSpecialCharacters = true;

        [TestInitialize]
        public void Setup()
        {
            settings = new PasswordManager.GeneratePasswordSettings(passwordLength, includeLowerCase, includeUpperCase, includeNumbers, includeSpecialCharacters);
        }

        [TestCleanup]
        public void Cleanup()
        {
            settings = null;
        }

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
