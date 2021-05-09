using System;

namespace PasswordManager
{
    public class ProfileController
    {

        private Profile profile;

        public ProfileController(string password) {
            this.profile = new Profile(password);
        }

        public bool ValidatePassword(string password)
        {
            return this.profile.ValidatePassword(password);
        }

        public void ChangePassword(string actualpassword, string newpassword)
        {
            this.profile.ChangePassword(actualpassword, newpassword);
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