using System.Collections.Generic;

namespace PasswordManager
{
    public class SystemProfile
    {
        public string SystemPassword {get; set;}
        private List<Categorie> categories;

        public SystemProfile(string password) {
            this.SystemPassword = password;
            categories = new List<Categorie>();
        }

        public bool Login(string password) 
        {
            return password.Equals(SystemPassword);
        }

        public void AddCategory(Categorie category) 
        {
            this.categories.Add(category);
        }

        public bool CategoryExists(Categorie category) 
        {
            return this.categories.Contains(category);
        }
    }
}