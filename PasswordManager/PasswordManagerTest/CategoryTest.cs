using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordManager;
using PasswordManager.Exceptions;

namespace PasswordManagerTest
{
    [TestClass]
    public class CategoryTest
    {
        Category personalCategory;

        [TestInitialize]
        public void Setup()
        {
            personalCategory = new Category("Personal");
        }

        [TestCleanup]
        public void Cleanup()
        {
            personalCategory = null;
        }

        [TestMethod]
        public void CreateCategoryWithValidName()
        {
            string validName = "Personal";
            Assert.AreEqual(personalCategory.Name,validName);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCategoryNameException))]
        public void CreateCategoryWithNameShorterThanTheMinimumValidLength()
        {
            string invalidName = "NA";
            Category invalidNameCategory = new Category(invalidName);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCategoryNameException))]
        public void CreateCategoryWithNameLongerThanTheMaximumValidLength()
        {
            string invalidName = "0123456789ABCDEF";
            Category invalidNameCategory = new Category(invalidName);
        }

        [TestMethod]
        public void CategoryObjectToStringShouldSayItsName() 
        {
            string validName = "Personal";
            Assert.AreEqual(personalCategory.ToString(), validName);
        }

        [TestMethod]
        public void ChangeCategoryNameWithValidName() 
        {
            string newName = "Trabajo";
            personalCategory.ChangeName(newName);
            Assert.AreEqual(personalCategory.Name, newName);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCategoryNameException))]
        public void ChangeCategoryNameWithInvalidName()
        {
            string invalidNewName = "PC";
            personalCategory.ChangeName(invalidNewName);
        }

        [TestMethod]
        public void CategorysWithSameNameAreEqual() 
        {
            Category categoryWithSameName = new Category("PERSONAL");
            Assert.IsTrue(personalCategory.IsEqual(categoryWithSameName));
        }

        [TestMethod]
        public void VerifyCategoryId()
        {
            personalCategory.Id = 1;
            Assert.AreEqual(1, personalCategory.Id);
        }
    }
}
