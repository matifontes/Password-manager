using System;
using System.Collections.Generic;
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
            Category category = new Category(categoryEntity.Name);
            return category;
        }

        public PasswordEntity PasswordToEntity(Password password) 
        {
            PasswordEntity passwordEntity = new PasswordEntity()
            {
                Site = password.Site,
                User = password.User,
                Password = password.Pass,
                Note = password.Note,
                Strength = password.Strength,
                LastModificationDate = password.LastModificationDate

            };

            return passwordEntity;
        }

        /*
        public Password EntityToPassword(PasswordEntity passwordEntity) 
        {
            Password password = new Password(passwordEntity.);
        }*/

    }
}
