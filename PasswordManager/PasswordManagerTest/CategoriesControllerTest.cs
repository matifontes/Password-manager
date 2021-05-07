using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PasswordManager;
using System.Collections.Generic;

namespace PasswordManagerTest
{
    [TestClass]
    public class CategoriesControllerTest
    {
        [TestMethod]
        public void CreateNewCategoriesController()
        {
            CategoryRepository categories = new CategoryRepository();
            CategoriesController categoriesController = new CategoriesController(categories);
            Assert.AreEqual(categoriesController.Count(),0);
        }
       
        [TestMethod]
        public void AddCategory() 
        {
            CategoryRepository categories = new CategoryRepository();
            CategoriesController categoriesController = new CategoriesController(categories);
            Category category = new Category("Personal");

            categoriesController.AddCategory(category);
            Assert.AreEqual(categoriesController.Count(),1);
        }

        [TestMethod]
        public void RemoveCategory()
        {
            CategoryRepository categories = new CategoryRepository();
            CategoriesController categoriesController = new CategoriesController(categories);
            Category category = new Category("Personal");
            categoriesController.AddCategory(category);

            categoriesController.RemoveCategory(category);
            Assert.AreEqual(categoriesController.Count(), 0);
        }

        [TestMethod]
        public void ListCategoriesOrderByName()
        {
            CategoryRepository categories = new CategoryRepository();
            CategoriesController categoriesController = new CategoriesController(categories);
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
