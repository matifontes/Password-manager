﻿using System;
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
    }
}
