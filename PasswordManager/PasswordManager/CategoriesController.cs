using System.Collections.Generic;

namespace PasswordManager
{
    public class CategoriesController
    {
        private CategoryRepository categories;

        public CategoriesController() 
        {
            categories = new CategoryRepository();
        }

        public void AddCategory(Category category) 
        {
            this.categories.AddCategory(category);  
        }

        public void RemoveCategory(Category category) 
        {
            this.categories.RemoveCategory(category);
        }

        public int Count() 
        {
           return this.categories.Count();
        }

        public List<Category> ListCategories() 
        {
            return this.categories.ListCategories();
        }
    }
}