using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PasswordManagerDataLeyer.RepositoriesDB;
using PasswordManager;

namespace DataLeyer.Test
{
    [TestClass]
    public class CategoryRepositoryTest
    {
        [TestMethod]
        public void AddCategoryToRepository()
        {
            ProfileRepository profileRepository = new ProfileRepository();
            Profile profile = new Profile("TESTPROFILE");
            profileRepository.Add(profile);

            CategoryRepository categoryRepository = new CategoryRepository(profile);
            Category category = new Category("PERSONAL");
            categoryRepository.Add(category);

            
            Assert.AreEqual(category.Name, categoryRepository.Get(category.Name).Name);
        }
    }
}
