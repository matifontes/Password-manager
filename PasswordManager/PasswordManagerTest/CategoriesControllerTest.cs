using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PasswordManager;
using System.Collections.Generic;
using PasswordManager.Controllers;
using PasswordManager.Exceptions;
using PasswordManager.Repositories;

namespace PasswordManagerTest
{
    [TestClass]
    public class CategoriesControllerTest
    {
        private CategoryRepository categories;
        private CategoriesController categoriesController;
        [TestInitialize]
        public void Setup() 
        {
            categories = new CategoryRepository();
            categoriesController = new CategoriesController(categories);
        }

        [TestCleanup]
        public void Cleanup() 
        {
            categories = null;
            categoriesController = null;
        }
            
        [TestMethod]
        public void CreateNewCategoriesController()
        {          
            Assert.AreEqual(categoriesController.Count(),0);
        }

        [TestMethod]
        public void CreateNewCategoriesControllerShouldBeEmpty()
        {
            Assert.IsTrue(categoriesController.IsEmpty());
        }

        [TestMethod]
        public void AddCategory() 
        {
            Category category = new Category("Personal");

            categoriesController.AddCategory(category);
            Assert.AreEqual(categoriesController.Count(),1);
        }

        [TestMethod]
        public void ControllerContainsCategoryAddedToIt()
        {
            Category category = new Category("Personal");

            categoriesController.AddCategory(category);
            Assert.IsTrue(categoriesController.ContainsCategory(category));
        }

        [TestMethod]
        [ExpectedException(typeof(CategoryAlreadyExistsException))]
        public void AddCategoryThatAlreadyExistsThrowsException()
        {
            Category category = new Category("Personal");
            Category sameCategory = new Category("PERSONAL");
            categoriesController.AddCategory(category);
            categoriesController.AddCategory(sameCategory);
        }

        [TestMethod]
        public void CategoriesControllerWithACategoryShouldntBeEmpty()
        {
            Category category = new Category("Personal");

            categoriesController.AddCategory(category);
            Assert.IsFalse(categoriesController.IsEmpty());
        }

        [TestMethod]
        public void RemoveCategory()
        {
            Category category = new Category("Personal");
            categoriesController.AddCategory(category);

            categoriesController.RemoveCategory(category);
            Assert.AreEqual(categoriesController.Count(), 0);
        }

        [TestMethod]
        public void ListCategoriesOrderByName()
        {
            Category category1 = new Category("Personal");
            Category category2 = new Category("Trabajo");
            Category category3 = new Category("Gaming");
            categoriesController.AddCategory(category1);
            categoriesController.AddCategory(category2);
            categoriesController.AddCategory(category3);

            List<Category> orderedCategories = categoriesController.ListCategories();

            Assert.AreEqual(orderedCategories[0].Name, category3.Name);
            Assert.AreEqual(orderedCategories[1].Name, category1.Name);
            Assert.AreEqual(orderedCategories[2].Name, category2.Name);
        }
    }
}
