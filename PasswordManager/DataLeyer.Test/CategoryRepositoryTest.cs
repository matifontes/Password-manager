using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PasswordManagerDataLeyer.RepositoriesDB;
using PasswordManager;
using PasswordManagerDataLeyer;

namespace DataLeyer.Test
{
    [TestClass]
    public class CategoryRepositoryTest
    {
        private ProfileRepository profileRepository;
        private Profile profile;
        private CategoryRepository categoryRepository;
        private Category category;

        [TestInitialize]
        public void Setup() 
        {
            profileRepository = new ProfileRepository();
            profile = new Profile("TESTPROFILE");
            profileRepository.Add(profile);
            categoryRepository = new CategoryRepository(profile);
            category = new Category("PERSONAL");
        }

        [TestCleanup]
        public void Cleanup() 
        {
            foreach (Category ctgr in categoryRepository.GetAll())
            {
                categoryRepository.Delete(ctgr.Id);
            }
            foreach (Profile prfl in profileRepository.GetAll())
            {
                profileRepository.Delete(prfl.Id);
            }
            category = null;
            profile = null;
        }

        [TestMethod]
        public void AddCategoryToRepository()
        {
            categoryRepository.Add(category);

            Assert.AreEqual(category.Name, categoryRepository.Get(category.Id).Name);
        }

        [TestMethod]
        public void RepositoryWithotCategoriesShouldBeEmpty() 
        {
            Assert.IsTrue(categoryRepository.IsEmpty());
        }

        [TestMethod]
        [ExpectedException(typeof(CategoryAlreadyExistsException))]
        public void AddCategoryThatAlreadyExistsThrowsException() 
        {
            categoryRepository.Add(category);
            categoryRepository.Add(new Category(category.Name));
        }

        [TestMethod]
        public void ChangeCategoryName() 
        {
            categoryRepository.Add(category);
            category.ChangeName("TRABAJO");
            categoryRepository.Update(category);
            Assert.AreEqual(category.Name,categoryRepository.Get(category.Id).Name);
        }

        [TestMethod]
        [ExpectedException(typeof(CategoryAlreadyExistsException))]
        public void ChangeCategoryNameToOneThatAlreadyExistsOnRepository() 
        {
            categoryRepository.Add(category);
            categoryRepository.Add(new Category("TRABAJO"));
            category.ChangeName("TRABAJO");
            categoryRepository.Update(category);
        }
    }
}
