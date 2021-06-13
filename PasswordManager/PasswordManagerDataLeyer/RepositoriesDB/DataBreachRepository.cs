using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManager;

namespace PasswordManagerDataLeyer.RepositoriesDB
{
    public class DataBreachRepository : IRepository<DataBreach>
    {
        private Mapper mapper = new Mapper();
        private Profile profile;

        public DataBreachRepository(Profile profile) 
        {
            this.profile = profile;
        }

        public void Add(DataBreach dataBreach) 
        {
            using (PasswordManagerContext context = new PasswordManagerContext()) 
            {
                if(context.DataBreaches.Any(d => d.Date == dataBreach.Date || d.Id == dataBreach.Id)) {
                    throw new DataBreachAlreadyExistsException();
                }
                DataBreachEntity entity = mapper.DataBreachToEntity(dataBreach);
                entity.Profile = context.Profiles.Find(this.profile.Id);
                foreach (Password password in dataBreach.passwords) 
                {
                    entity.PasswordsEntity.Add(context.Passwords.Find(password.Id));
                }
                foreach (CreditCard creditCard in dataBreach.creditCards)
                {
                    entity.CreditCardEntity.Add(context.CreditCards.Find(creditCard.Id));
                }
                context.DataBreaches.Add(entity);
                context.SaveChanges();
                dataBreach.Id = entity.Id;
            }
        }

        public bool IsEmpty() 
        {
            using (PasswordManagerContext context = new PasswordManagerContext())
            {
                return context.DataBreaches.Count() == 0;
            }
        }

        public DataBreach Get(int id) 
        {
            using (PasswordManagerContext context = new PasswordManagerContext())
            {
                return mapper.EntityToDataBreach(context.DataBreaches.Find(id));
            }
        }

        public IEnumerable<DataBreach> GetAll() 
        {
            using (PasswordManagerContext context = new PasswordManagerContext())
            {
                List<DataBreach> dataBreaches = new List<DataBreach>();
                foreach(DataBreachEntity entity in context.DataBreaches.ToList()) 
                {
                    dataBreaches.Add(mapper.EntityToDataBreach(entity));
                }
                return dataBreaches;
            }
        }
        public void Delete(int id) 
        {
            using (PasswordManagerContext context = new PasswordManagerContext())
            {
                DataBreachEntity entity = context.DataBreaches.Find(id);
                if(entity != null) 
                {
                    context.DataBreaches.Remove(entity);
                    context.SaveChanges();
                }
            }
        }
        public void Update(DataBreach entity) 
        {
            throw new NotImplementedException();
        }
    }
}
