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
                Id = password.Id,
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
                Id = creditCard.Id,
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

        public DataBreach EntityToDataBreach(DataBreachEntity dataBreachEntity) 
        {
            List<Password> passwords = new List<Password>();
            List<CreditCard> cards = new List<CreditCard>();
            List<PasswordEntity> passwordsEntity = (List<PasswordEntity>)dataBreachEntity.PasswordsEntity;
            List<CreditCardEntity> creditCardsEntity = (List<CreditCardEntity>)dataBreachEntity.CreditCardEntity;
            foreach (PasswordEntity password in passwordsEntity) 
            {
                passwords.Add(EntityToPassword(password));
            }
            foreach (CreditCardEntity creditCard in creditCardsEntity) 
            {
                cards.Add(EntityToCreditCard(creditCard));
            }
            DataBreach dataBreach = new DataBreach(cards, passwords)
            {
                Date = dataBreachEntity.Date,
                Id = dataBreachEntity.Id
            };
            return dataBreach;
        }

        public DataBreachEntity DataBreachToEntity(DataBreach dataBreach) 
        {
            DataBreachEntity dataBreachEntity = new DataBreachEntity() 
            {
                Id = dataBreach.Id,
                Date = dataBreach.Date
            };
             return dataBreachEntity;
        }
    }
}
