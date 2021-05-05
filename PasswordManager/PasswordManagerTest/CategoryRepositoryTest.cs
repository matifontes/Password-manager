using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PasswordManager;

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
    }
}
