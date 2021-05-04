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
            return this.profile.ValidateSystemPassword(password);
        }
    }
}