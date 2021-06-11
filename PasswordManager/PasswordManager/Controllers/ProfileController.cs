using System;
using PasswordManager.Repositories;

namespace PasswordManager.Controllers
{
    public class ProfileController
    {

        private Profile profile;

        public ProfileController(string password) {
            this.profile = new Profile(password);
        }
        public ProfileController(Profile profile)
        {
            this.profile = profile;
        }

        public bool ValidatePassword(string password)
        {
            return this.profile.ValidatePassword(password);
        }

        public void ChangePassword(string actualpassword, string newpassword)
        {
            this.profile.ChangePassword(actualpassword, newpassword);
        }

        public Profile GetProfile() 
        {
            return this.profile;
        }

        public int GetId() 
        {
            return this.profile.Id;
        }

        public CategoryRepository GetCategoryRepository() 
        {
            return this.profile.GetCategoryRepository();
        }
        public PasswordRepository GetPasswordRepository()
        {
            return this.profile.GetPasswordRepository();
        }
        public CreditCardRepository GetCreditCardRepository()
        {
            return this.profile.GetCreditCardRepository();
        }
    }
}