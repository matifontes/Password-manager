using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManager;
using PasswordManager.Exceptions;

namespace PasswordManagerDataLeyer.RepositoriesDB
{
    public class CreditCardRepository : IRepository<CreditCard>,ISearchable<CreditCard>
    {
        const string CREDIT_CARD_ALREADY_EXISTS_MSG = "La Tarjeta de credito ya existe";
        private Mapper mapper = new Mapper();
        private Profile profile;

        public CreditCardRepository(Profile profile) 
        {
            this.profile = profile;
        }

        public void Add(CreditCard creditCard) 
        {
            using (PasswordManagerContext context = new PasswordManagerContext())
            {
                if (context.CreditCards.Any(c => c.Number == creditCard.Number))
                {
                    throw new CreditCardAlreadyExistsException(CREDIT_CARD_ALREADY_EXISTS_MSG);
                }

                CreditCardEntity entity = mapper.CreditCardToEntity(creditCard);
                entity.Profile = context.Profiles.Find(this.profile.Id);
                entity.CategoryEntity = context.Categories.Include("ProfileEntity").Where(p => p.Id == creditCard.Category.Id).FirstOrDefault<CategoryEntity>();
                context.CreditCards.Add(entity);
                context.SaveChanges();
                creditCard.Id = entity.Id;
            }
        }

        public bool IsEmpty()
        {
            using (PasswordManagerContext context = new PasswordManagerContext())
            {
                return context.CreditCards.Count() == 0;
            }
        }

        public CreditCard Get(int id) 
        {
            using (PasswordManagerContext context = new PasswordManagerContext())
            {
                var entity = context.CreditCards.Include("CategoryEntity").Where(c => c.Id == id).FirstOrDefault<CreditCardEntity>();
                if (entity == null)
                {
                    throw new PasswordNotFoundException();
                }

                CreditCard creditCard = mapper.EntityToCreditCard(entity);
                return creditCard;
            }
        }

        public IEnumerable<CreditCard> GetAll() 
        {
            List<CreditCard> creditCards = new List<CreditCard>();
            using (PasswordManagerContext context = new PasswordManagerContext())
            {
                foreach(CreditCardEntity entity in context.CreditCards.ToList())
                {
                    creditCards.Add(mapper.EntityToCreditCard(entity));
                }
            }
            return creditCards;
        }

        public void Delete(int id) 
        {
            using (PasswordManagerContext context = new PasswordManagerContext())
            {
                CreditCardEntity entity = context.CreditCards.Find(id);
                if (entity != null)
                {
                    context.CreditCards.Remove(entity);
                    context.SaveChanges();
                }
            }
        }

        public void Update(CreditCard creditCard) 
        {
            using (PasswordManagerContext context = new PasswordManagerContext())
            {
                if (context.CreditCards.Any(c => c.Number == creditCard.Number && c.Id != creditCard.Id))
                {
                    throw new CreditCardAlreadyExistsException(CREDIT_CARD_ALREADY_EXISTS_MSG);
                }
                CreditCardEntity entity = context.CreditCards.Find(creditCard.Id);
                if (entity == null)
                {
                    throw new CategoryNotFoundException();
                }
                entity.CategoryEntity = context.Categories.Find(creditCard.Category.Id);
                entity.Number = creditCard.Number;
                entity.Name = creditCard.Name;
                entity.Type = creditCard.Type;
                entity.CCVCode = creditCard.CCVCode;
                entity.Note = creditCard.Note;
                entity.ExpiryDate = creditCard.ExpiryDate;
                context.SaveChanges();
            }
        }

        public IEnumerable<CreditCard> GetAllByProfile(int id) 
        {
            using (PasswordManagerContext context = new PasswordManagerContext())
            {
                List<CreditCard> creditCards = new List<CreditCard>();
                List<CreditCardEntity> entities = context.CreditCards.SqlQuery("SELECT p.* FROM dbo.CreditCardEntities p INNER JOIN CategoryEntities c ON p.CategoryEntity_Id = c.Id WHERE p.Profile_id=@id ORDER BY c.Name", new SqlParameter("@id", id)).ToList();
                foreach(CreditCardEntity entity in entities)
                {
                    creditCards.Add(mapper.EntityToCreditCard(entity));
                }
                return creditCards;
            }
        }

        public IEnumerable<CreditCard> GetAllWithSameNumber(List<CreditCard> creditCards) 
        {
            using (PasswordManagerContext context = new PasswordManagerContext())
            {
                List<CreditCard> matchingCreditCards = new List<CreditCard>();
                foreach (CreditCard creditCard in creditCards)
                {
                    List<CreditCardEntity> entities = context.CreditCards.SqlQuery("SELECT ccs.* FROM dbo.CreditCardEntities ccs INNER JOIN CategoryEntities c ON ccs.CategoryEntity_Id = c.Id WHERE ccs.Profile_id=@id AND ccs.Number=@number ORDER BY c.Name", new SqlParameter("@id", this.profile.Id), new SqlParameter("@number", creditCard.Number)).ToList();
                    foreach (CreditCardEntity entity in entities)
                    {
                        matchingCreditCards.Add(mapper.EntityToCreditCard(entity));
                    }
                }
                return matchingCreditCards;
            }
        }
    }
}
