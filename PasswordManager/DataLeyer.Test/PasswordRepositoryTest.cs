using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PasswordManagerDataLeyer.RepositoriesDB;
using PasswordManager;
using PasswordManager.Exceptions;

namespace DataLeyer.Test
{
    [TestClass]
    public class PasswordRepositoryTest
    {
        private ProfileRepository profileRepository;
        private Profile profile;
        private CategoryRepository categoryRepository;
        private Category category;
        private PasswordRepository passwordRepository;
        private Password password;
        private string pass = "admin";
        private string site = "aulas.ort.edu.uy";
        private string user = "Ralph";
        private string note = "nota";


        [TestInitialize]
        public void Setup() 
        {
            profileRepository = new ProfileRepository();
            profileRepository = new ProfileRepository();
            profile = new Profile("TESTPROFILE");
            profileRepository.Add(profile);
            categoryRepository = new CategoryRepository(profile);
            category = new Category("TEST");
            categoryRepository.Add(category);
            passwordRepository = new PasswordRepository(profile);
            password = new Password(category, pass, site, user, note);
        }

        [TestCleanup]
        public void Cleanup() 
        {
            foreach (Password psw in passwordRepository.GetAll()) 
            {
                passwordRepository.Delete(psw.Id);
            }
            foreach (Category ctgr in categoryRepository.GetAll())
            {
                categoryRepository.Delete(ctgr.Id);
            }
            foreach (Profile prfl in profileRepository.GetAll())
            {
                profileRepository.Delete(prfl.Id);
            }
            password = null;
            category = null;
            profile = null;
        }

        [TestMethod]
        public void AddPasswordToRepository()
        {
            passwordRepository.Add(password);

            Assert.AreEqual(password.Id,passwordRepository.Get(password.Id).Id);
        }
    }
}
