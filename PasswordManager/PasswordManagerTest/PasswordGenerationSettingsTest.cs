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
            GeneratePasswordSettings settings = new GeneratePasswordSettings();
            Assert.IsNotNull(settings);
        }
    }
}
