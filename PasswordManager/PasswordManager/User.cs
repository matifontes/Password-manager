namespace PasswordManager
{
    public class User
    {
        public string Password {get; set;}

        public User(string password) {
            this.Password = password;
        }
    }
}