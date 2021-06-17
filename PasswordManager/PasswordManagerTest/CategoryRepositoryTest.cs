using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PasswordManager;
using System.Collections.Generic;
using PasswordManager.Exceptions;
using PasswordManager.Repositories;

namespace PasswordManagerTest
{
    [TestClass]
    public class CategoryRepositoryTest
    {
        private string categoryName = "Personal";
        private Category category;
        private CategoryRepository categoryRepository;

        [TestInitialize]
        public void Setup() 
        {
            category = new Category(categoryName);
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
        public void CreateNewCategoryRepositoryShouldBeEmpty() 
        {
            Assert.IsTrue(categoryRepository.IsEmpty());
        }

        [TestMethod]
        public void AddCategory() 
        {
            categoryRepository.AddCategory(category);
            Assert.AreEqual(categoryRepository.Count(), 1);
        }

        [TestMethod]
        public void RepositoryShouldNotContainCategoryThatWasntAddedToIt() 
        {
            Assert.IsFalse(categoryRepository.ContainsCategory(category));
        }

        [TestMethod]
        public void RepositoryShouldContainAddedCategory()
        {
            categoryRepository.AddCategory(category);
            Assert.IsTrue(categoryRepository.ContainsCategory(category));
        }

        [TestMethod]
        [ExpectedException(typeof(CategoryAlreadyExistsException))]
        public void AddCategoryThatAlreadyExistsThrowsException() 
        {
            categoryRepository.AddCategory(category);
            Category categoryWithSameName = new Category(categoryName);
            categoryRepository.AddCategory(categoryWithSameName);
        }

        [TestMethod]
        [ExpectedException(typeof(CategoryAlreadyExistsException))]
        public void AddCategoryWhitSameNameDifferentCaseThrowsAlreadyExistsException()
        {
            categoryRepository.AddCategory(category);
            string categoryNameUperCase = categoryName.ToUpper();
            Category categoryWithSameName = new Category(categoryNameUperCase);
            categoryRepository.AddCategory(categoryWithSameName);
        }

        [TestMethod]
        public void CategoryRepositoryWithACategoryShouldntBeEmpty()
        {
            categoryRepository.AddCategory(category);
            Assert.IsFalse(categoryRepository.IsEmpty());
        }

        [TestMethod]
        public void RemoveCategory() 
        {
            categoryRepository.AddCategory(category);

            categoryRepository.RemoveCategory(category);

            Assert.AreEqual(categoryRepository.Count(), 0);
        }

        [TestMethod]
        public void ListCategoriesOrderByName() 
        {

            Category category2 = new Category("Trabajo");
            Category category3 = new Category("Gaming");
            categoryRepository.AddCategory(category);
            categoryRepository.AddCategory(category2);
            categoryRepository.AddCategory(category3);

            List<Category> orderedCategories = categoryRepository.ListCategories();

            Assert.AreEqual(orderedCategories[0].Name,category3.Name);
            Assert.AreEqual(orderedCategories[1].Name,category.Name);
            Assert.AreEqual(orderedCategories[2].Name,category2.Name);
        }
    }
}
