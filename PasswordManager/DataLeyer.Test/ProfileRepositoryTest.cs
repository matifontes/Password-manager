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
        [TestMethod]
        public void AddProfileToRepository()
        {
            Profile profile = new Profile("EXAMPLE");
            ProfileRepository profileRepository = new ProfileRepository();
            profileRepository.Add(profile);

            Assert.AreEqual(profile.Password, profileRepository.Get(profile.Id).Password);
        }
    }
}
