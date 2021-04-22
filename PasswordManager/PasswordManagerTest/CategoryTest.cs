using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordManager;

namespace PasswordManagerTest
{
    [TestClass]
    public class CategoryTest
    {
        [TestMethod]
        public void CreateCategoryWithValidName()
        {
            string validName = "Personal";
            Category personal = new Category(validName);
            Assert.IsNotNull(personal);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCategoryNameException))]
        public void CreateCategoryWithNameShorterThanTheMinimumValidLength()
        {
            string invalidName = "NA";
            Category personal = new Category(invalidName);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCategoryNameException))]
        public void CreateCategoryWithNameLongerThanTheMaximumValidLength()
        {
            string invalidName = "0123456789ABCDEF";

            Category personal = new Category(invalidName);
        }
    }
}
