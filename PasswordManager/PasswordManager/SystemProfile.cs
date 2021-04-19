using System.Collections.Generic;

namespace PasswordManager
{
    public class SystemProfile
    {
        public string SystemPassword {get; set;}
        private List<Category> categories;

        public SystemProfile(string password) {
            this.SystemPassword = password;
            categories = new List<Category>();
        }

        public bool Login(string password) 
        {
            return password.Equals(SystemPassword);
        }

        public void AddCategory(Category category) 
        {
            this.categories.Add(category);
        }

        public bool CategoryExists(Category category) 
        {
            return this.categories.Contains(category);
        }
    }
}