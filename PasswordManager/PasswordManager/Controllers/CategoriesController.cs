using System.Collections.Generic;
using PasswordManager.Repositories;

namespace PasswordManager.Controllers
{
    public class CategoriesController
    {
        private CategoryRepository categories;

        public CategoriesController(CategoryRepository categories) 
        {
            this.categories = categories;
        }

        public void AddCategory(Category category) 
        {
            this.categories.AddCategory(category);  
        }

        public bool ContainsCategory(Category category) 
        {
            return this.categories.ContainsCategory(category);
        }

        public void RemoveCategory(Category category) 
        {
            this.categories.RemoveCategory(category);
        }

        public bool IsEmpty() 
        {
            return this.categories.IsEmpty();
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