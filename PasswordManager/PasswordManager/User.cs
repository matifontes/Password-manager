namespace PasswordManager
{
    public class User
    {
        public string SystemPassword {get; set;}

        public User(string password) {
            this.SystemPassword = password;
        }
    }
}