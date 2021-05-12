using System.Collections.Generic;
using System.Linq;
using PasswordManager.Exceptions;

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
            if (this.ContainsCategory(category))
            {
                const string CATEGORY_ALREADY_EXISTS = "Ya existe una categoria con ese nombre";
                throw new CategoryAlreadyExistsException(CATEGORY_ALREADY_EXISTS);
            }
            else 
            {
                categories.Add(category);
            }
           
        }

        public bool ContainsCategory(Category category) 
        {
            foreach (Category cat in this.categories) 
            {
                if (cat.IsEqual(category)) 
                {
                    return true;
                }
            }
            return false;
        }

        public void RemoveCategory(Category category) 
        {
            categories.Remove(category);
        }

        public bool IsEmpty() 
        {
            return this.Count() == 0;
        }

        public int Count() 
        {
            return categories.Count;
        }

        public List<Category> ListCategories()
        {
            return this.categories.OrderBy(category => category.Name).ToList();
        }
    }
}