using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PasswordManager;
using PasswordManagerDataLeyer.RepositoriesDB;
using PasswordManagerDataLeyer;

namespace DataLeyer.Test
{
    [TestClass]
    public class ProfileRepositoryTest
    {
        private ProfileRepository profileRepository;
        private Profile profile;

        [TestInitialize]
        public void Setup() 
        {
            profileRepository = new ProfileRepository();
            profile = new Profile("EXAMPLE");
        }

        [TestCleanup]
        public void Cleanup() 
        {
            foreach (Profile prfl in profileRepository.GetAll())
            {
                profileRepository.Delete(prfl.Id);
            }
            profile = null;
            profileRepository = null;
        }

        [TestMethod]
        public void AddProfileToRepository()
        {
            profileRepository.Add(profile);

            Assert.AreEqual(profile.Password, profileRepository.Get(profile.Id).Password);
        }

        [TestMethod]
        public void RepositoryWithoutAProfileShouldBeEmpty() 
        {
            Assert.IsTrue(profileRepository.IsEmpty());
        }

        [TestMethod]
        [ExpectedException(typeof(ProfileNotFoundException))]
        public void ProfileDeletedShouldntBeFoundOnTheRepository() 
        {
            profileRepository.Add(profile);
            profileRepository.Delete(profile.Id);
            profileRepository.Get(profile.Id);
        }
    }
}
