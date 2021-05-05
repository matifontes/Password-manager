using System.Collections.Generic;

namespace PasswordManager
{
    public class CategoryRepository
    {
        private List<Category> categories;
        public CategoryRepository() 
        {
            categories = new List<Category>();
        }

        public void AddCategory(Category category) 
        {
            categories.Add(category);
        }

        public void RemoveCategory(Category category) 
        {
            categories.Remove(category);
        }

        public int Count() 
        {
            return categories.Count;
        }
    }
}