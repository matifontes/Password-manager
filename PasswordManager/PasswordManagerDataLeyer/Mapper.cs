using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManager;

namespace PasswordManagerDataLeyer
{
    public class Mapper
    {
        public ProfileEntity ProfileToEntity(Profile profile) 
        {
            ProfileEntity profileEntity = new ProfileEntity
            {
                Password = profile.Password
            };
            return profileEntity;
        }

        public Profile EntityToProfile(ProfileEntity profileEntity) 
        {
            Profile profile = new Profile(profileEntity.Password)
            {
                Id = profileEntity.Id
            };
            return profile;
        }

        public CategoryEntity CategoryToEntity(Category category)
        {
            CategoryEntity categoryEntity = new CategoryEntity() 
            {
                Name = category.Name
            };
            return categoryEntity;
        }

        public Category EntityToCategory(CategoryEntity categoryEntity) 
        {
            Category category = new Category(categoryEntity.Name)
            { Id = categoryEntity.Id };
            return category;
        }

        public PasswordEntity PasswordToEntity(Password password) 
        {
            PasswordEntity passwordEntity = new PasswordEntity();
            using (PasswordManagerContext context = new PasswordManagerContext())
            {
                passwordEntity.Site = password.Site;
                passwordEntity.User = password.User;
                passwordEntity.Password = password.Pass;
                passwordEntity.Note = password.Note;
                passwordEntity.Strength = password.Strength;
                passwordEntity.LastModificationDate = password.LastModificationDate;
            }
            return passwordEntity;
        }

        public Password EntityToPassword(PasswordEntity passwordEntity) 
        {
            using (PasswordManagerContext context = new PasswordManagerContext())
            {
                CategoryEntity entity = passwordEntity.CategoryEntity;
                Category category = EntityToCategory(entity);
                Password password = new Password(category, passwordEntity.Password, passwordEntity.Site, passwordEntity.User, passwordEntity.Note);
                {
                    password.Id = passwordEntity.Id;
                }
                return password;
            }
        }
    }
}
