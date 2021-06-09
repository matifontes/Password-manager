﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManager;

namespace PasswordManagerDataLeyer.RepositoriesDB
{
    public class CategoryRepository : IRepository<Category>
    {
        private Mapper mapper = new Mapper();
        private Profile profile;
        private ProfileEntity profileEntity;

        public CategoryRepository(Profile profile) 
        {
            this.profile = profile;
            this.LoadProfileEntity();
        }

        public void Add(Category category)
        {
            using (PasswordManagerContext context = new PasswordManagerContext())
            {
                if(context.Categories.Any(c => c.Name == category.Name)) 
                {
                    throw new CategoryAlreadyExistsException();
                }

                CategoryEntity entity = mapper.CategoryToEntity(category);
                entity.Profile = this.profileEntity;
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
                    throw new CategoryAlreadyExistsException();
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

        private void LoadProfileEntity() 
        {
            using (PasswordManagerContext context = new PasswordManagerContext())
            {
                ProfileEntity entity = context.Profiles.Find(this.profile.Id);
                if (entity == null)
                {
                    throw new ProfileNotFoundException();
                }
                this.profileEntity = context.Profiles.Find(this.profile.Id);
            }
        }
    }
}
