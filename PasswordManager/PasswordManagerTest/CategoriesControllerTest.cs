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
            CategoriesController categoriesController = new CategoriesController();
            Assert.IsNotNull(categoriesController.Count(),0);
        }
       
        [TestMethod]
        public void AddCategory() 
        {
            CategoriesController categoriesController = new CategoriesController();
            Category category = new Category("Personal");

            categoriesController.AddCategory(category);
            Assert.IsNotNull(categoriesController.Count(),1);
        }

        [TestMethod]
        public void RemoveCategory()
        {
            CategoriesController categoriesController = new CategoriesController();
            Category category = new Category("Personal");
            categoriesController.AddCategory(category);

            categoriesController.RemoveCategory(category);
            Assert.IsNotNull(categoriesController.Count(), 0);
        }

        [TestMethod]
        public void ListCategoriesOrderByName()
        {
            CategoriesController categoriesController = new CategoriesController();
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
