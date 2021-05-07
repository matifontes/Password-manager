﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PasswordManager;
using System.Collections.Generic;

namespace PasswordManagerTest
{
    [TestClass]
    public class CategoryRepositoryTest
    {
        private Category category;
        private CategoryRepository categoryRepository;

        [TestInitialize]
        public void Setup() 
        {
            category = new Category("Personal");
            categoryRepository = new CategoryRepository();
        }

        [TestCleanup]
        public void Cleanup() 
        {
            category = null;
            categoryRepository = null;
        }

        [TestMethod]
        public void CreateCategoryRepository()
        {
            Assert.IsNotNull(categoryRepository);
        }

        [TestMethod]
        public void AddCategory() 
        {
            categoryRepository.AddCategory(category);

            Assert.AreEqual(categoryRepository.Count(), 1);
        }

        [TestMethod]
        public void RemoveCategory() 
        {
            categoryRepository.AddCategory(category);

            categoryRepository.RemoveCategory(category);

            Assert.AreEqual(categoryRepository.Count(), 0);
        }

        [TestMethod]
        public void ListCategories() 
        {

            Category category2 = new Category("Trabajo");
            Category category3 = new Category("Gaming");
            categoryRepository.AddCategory(category);
            categoryRepository.AddCategory(category2);
            categoryRepository.AddCategory(category3);

            List<Category> orderedCategories = categoryRepository.ListCategories();

            Assert.AreEqual(orderedCategories[0],category3);
            Assert.AreEqual(orderedCategories[1],category2);
            Assert.AreEqual(orderedCategories[2],category);
        }
    }
}
