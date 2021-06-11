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
            PasswordEntity passwordEntity = new PasswordEntity() {
                Site = password.Site,
                User = password.User,
                Password = password.Pass,
                Note = password.Note,
                Strength = password.Strength,
                LastModificationDate = password.LastModificationDate
            };
            return passwordEntity;
        }

        public Password EntityToPassword(PasswordEntity passwordEntity) 
        {
            CategoryEntity entity = passwordEntity.CategoryEntity;
            Category category = EntityToCategory(entity);
            Password password = new Password(category, passwordEntity.Password, passwordEntity.Site, passwordEntity.User, passwordEntity.Note);
            {
                password.Id = passwordEntity.Id;
            }
            return password;
        }

        public CreditCardEntity CreditCardToEntity(CreditCard creditCard) 
        {
            CreditCardEntity entity = new CreditCardEntity()
            {
                Name = creditCard.Name,
                Type = creditCard.Type,
                Number = creditCard.Number,
                CCVCode = creditCard.CCVCode,
                ExpiryDate = creditCard.ExpiryDate,
                Note = creditCard.Note
            };
            return entity;
        }

        public CreditCard EntityToCreditCard(CreditCardEntity creditCardEntity) 
        {
            CategoryEntity entity = creditCardEntity.CategoryEntity;
            Category category = EntityToCategory(entity);
            CreditCard creditCard = new CreditCard(category, creditCardEntity.Name, creditCardEntity.Type, creditCardEntity.Number, creditCardEntity.CCVCode, creditCardEntity.ExpiryDate, creditCardEntity.Note)
            {
                Id = creditCardEntity.Id
            };
            return creditCard;
        }
    }
}
