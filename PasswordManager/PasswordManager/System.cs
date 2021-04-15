namespace PasswordManager
{
    public class System
    {
        public string SystemPassword {get; set;}

        public System(string password) {
            this.SystemPassword = password;
        }

        public bool Login(string password) 
        {
            return password.Equals(SystemPassword);
        }
    }
}