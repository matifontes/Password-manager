using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManager;

namespace PasswordManagerDataLeyer.RepositoriesDB
{
    public class CategoryRepository : IRepository<Category>, ISearchable<Category>
    {
        const string CATEGORY_ALREADY_EXISTS = "Existe una categoria con ese nombre";
        private Mapper mapper = new Mapper();
        private Profile profile;

        public CategoryRepository(Profile profile) 
        {
            this.profile = profile;
        }

        public void Add(Category category)
        {
            using (PasswordManagerContext context = new PasswordManagerContext())
            {
                if(context.Categories.Any(c => c.Name == category.Name)) 
                {
                    throw new CategoryAlreadyExistsException(CATEGORY_ALREADY_EXISTS);
                }

                CategoryEntity entity = mapper.CategoryToEntity(category);
                entity.Profile = context.Profiles.Find(this.profile.Id);
                context.Categories.Add(entity);
                context.SaveChanges();
                category.Id = entity.Id;
            }
        }

        public bool IsEmpty() 
        {
            using (PasswordManagerContext context = new PasswordManagerContext())
            {
                return context.Categories.Count() == 0;
            }
        }

        public Category Get(int id) 
        {
            using (PasswordManagerContext context = new PasswordManagerContext())
            {
                CategoryEntity entity = context.Categories.Find(id);
                if(entity == null) 
                {
                    throw new CategoryNotFoundException();
                }

                Category category = mapper.EntityToCategory(entity);
                return category;
            }
        }

        public IEnumerable<Category> GetAll() 
        {
            List<Category> categories = new List<Category>();
            using (PasswordManagerContext context = new PasswordManagerContext())            
            {
                foreach (CategoryEntity entity in context.Categories.ToList()) 
                {
                    categories.Add(mapper.EntityToCategory(entity));
                }
            }
            return categories;
        }

        public void Delete(int id)
        {
            using (PasswordManagerContext context = new PasswordManagerContext())
            {
                CategoryEntity entity = context.Categories.Find(id);
                if(entity != null) 
                {
                    context.Categories.Remove(entity);
                    context.SaveChanges();
                }
            }
        }

        public void Update(Category category)
        {
            using (PasswordManagerContext context = new PasswordManagerContext())
            {
                if (context.Categories.Any(c => c.Name == category.Name))
                {
                    throw new CategoryAlreadyExistsException(CATEGORY_ALREADY_EXISTS);
                }
                CategoryEntity entity = context.Categories.Find(category.Id);
                if (entity == null)
                {
                    throw new CategoryNotFoundException();
                }
                entity.Name = category.Name;
                context.SaveChanges();
            }
        }

        public IEnumerable<Category> GetAllByProfile(int id) 
        {
            using (PasswordManagerContext context = new PasswordManagerContext())
            {
                List<Category> categories = new List<Category>();
                List<CategoryEntity> entities = context.Categories.SqlQuery("SELECT * FROM CategoryEntities WHERE Profile_Id=@id ORDER By Name", new SqlParameter("@id", id)).ToList();
                foreach (CategoryEntity entity in entities) 
                {
                    categories.Add(mapper.EntityToCategory(entity));
                }
                return categories;
            }

        }
    }
}
