using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PasswordManagerDataLeyer.RepositoriesDB;
using PasswordManager;

namespace DataLeyer.Test
{
    [TestClass]
    public class CreditCardRepositoryTest
    {
        private ProfileRepository profileRepository;
        private Profile profile;
        private CategoryRepository categoryRepository;
        private Category category;
        private CreditCardRepository creditCardRepository;
        private CreditCard creditCard;
        private string name = "Visa Gold";
        private string type = "Visa";
        private long creditCardNumber = 2323321323212321;
        private short ccvCode = 080;
        private DateTime expDate = new DateTime(2021, 5, 1);
        private string note = "card for USA";

        [TestInitialize]
        public void Setup() 
        {
            profileRepository = new ProfileRepository();
            profile = new Profile("TESTS");
            profileRepository.Add(profile);
            categoryRepository = new CategoryRepository(profile);
            category = new Category("PERSONAL");
            categoryRepository.Add(category);
            creditCardRepository = new CreditCardRepository(profile);
            creditCard = new CreditCard(category, name, type, creditCardNumber, ccvCode, expDate, note);
        }

        [TestCleanup]
        public void Cleanup() 
        {
            foreach (CreditCard ccr in creditCardRepository.GetAll())
            {
                creditCardRepository.Delete(ccr.Id);
            }
            foreach (Category ctgr in categoryRepository.GetAll())
            {
                categoryRepository.Delete(ctgr.Id);
            }
            foreach (Profile prfl in profileRepository.GetAll())
            {
                profileRepository.Delete(prfl.Id);
            }
            creditCard = null;
            category = null;
            profile = null;
        }

        [TestMethod]
        public void AddCreditCardToRepository()
        {
            creditCardRepository.Add(creditCard);

            Assert.AreEqual(creditCard.Id,creditCardRepository.Get(creditCard.Id).Id);
        }
    }
}
