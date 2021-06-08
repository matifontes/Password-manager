using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordManager;
using PasswordManager.Exceptions;

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
            Assert.AreEqual(personal.Name,validName);
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

        [TestMethod]
        public void CategoryObjectToStringShouldSayItsName() 
        {
            string validName = "Personal";
            Category personal = new Category(validName);
            Assert.AreEqual(personal.ToString(), validName);
        }

        [TestMethod]
        public void ChangeCategoryNameWithValidName() 
        {
            Category category = new Category("Personal");
            string newName = "Trabajo";
            category.ChangeName(newName);
            Assert.AreEqual(category.Name, newName);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCategoryNameException))]
        public void ChangeCategoryNameWithInvalidName()
        {
            Category category = new Category("Personal");
            string invalidNewName = "PC";
            category.ChangeName(invalidNewName);
        }

        [TestMethod]
        public void CategorysWithSameNameAreEqual() 
        {
            Category category = new Category("Personal");
            Category categoryWithSameName = new Category("PERSONAL");
            Assert.IsTrue(category.IsEqual(categoryWithSameName));
        }
    }
}
