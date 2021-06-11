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
    public class PasswordRepository : IRepository<Password>, ISearchable<Password>
    {
        const string PASSWORD_ALREADY_EXISTS_MSG = "El conjunto Usuario Sitio de la contraseña ya existe";
        private Mapper mapper = new Mapper();
        private Profile profile;

        public PasswordRepository(Profile profile) 
        {
            this.profile = profile;
        }

        public void Add(Password password) 
        {
            using (PasswordManagerContext context = new PasswordManagerContext()) 
            {
                if (context.Passwords.Any(p => p.Site == password.Site && p.User == password.User)) 
                {
                    throw new PasswordAlreadyExistsException(PASSWORD_ALREADY_EXISTS_MSG);
                }

                PasswordEntity entity = mapper.PasswordToEntity(password);
                entity.Profile = context.Profiles.Find(this.profile.Id);
                entity.CategoryEntity = context.Categories.Include("ProfileEntity").Where(p => p.Id == password.Category.Id).FirstOrDefault<CategoryEntity>();
                context.Passwords.Add(entity);
                context.SaveChanges();
                password.Id = entity.Id;
            }
        }
        public bool IsEmpty() 
        {
            using (PasswordManagerContext context = new PasswordManagerContext())
            {
                return context.Passwords.Count() == 0;
            }
        }
        public Password Get(int id) 
        {
            using (PasswordManagerContext context = new PasswordManagerContext())
            {
                //PasswordEntity entity = (PasswordEntity)context.Passwords.Where(p => p.Id == id);
                var entity = context.Passwords.Include("CategoryEntity").Where(p => p.Id == id).FirstOrDefault<PasswordEntity>();
                //CategoryEntity categoryEntity = 
                if (entity == null)
                {
                    throw new PasswordNotFoundException();
                }

                Password password = mapper.EntityToPassword(entity);
                return password;
            }
        }
        public IEnumerable<Password> GetAll() 
        {
            List<Password> passwords = new List<Password>();
            using (PasswordManagerContext context = new PasswordManagerContext())
            {
                foreach (PasswordEntity entity in context.Passwords.ToList())
                {
                    passwords.Add(mapper.EntityToPassword(entity));
                }
            }
            return passwords;
        }
        public void Delete(int id) 
        {
            using (PasswordManagerContext context = new PasswordManagerContext())
            {
                PasswordEntity entity = context.Passwords.Find(id);
                if (entity != null)
                {
                    context.Passwords.Remove(entity);
                    context.SaveChanges();
                }
            }
        }
        public void Update(Password password) 
        {
            using (PasswordManagerContext context = new PasswordManagerContext())
            {
                if (context.Passwords.Any(p => p.Site == password.Site && p.User == password.User && p.Id != password.Id))
                {
                    throw new CategoryAlreadyExistsException(PASSWORD_ALREADY_EXISTS_MSG);
                }
                PasswordEntity entity = context.Passwords.Find(password.Id);
                if (entity == null)
                {
                    throw new CategoryNotFoundException();
                }
                entity.CategoryEntity = context.Categories.Find(password.Category.Id);
                entity.User = password.User;
                entity.Site = password.Site;
                entity.Password = password.Pass;
                entity.Note = password.Note;
                entity.LastModificationDate = password.LastModificationDate;
                entity.Strength = password.Strength;
                context.SaveChanges();
            }
        }

        public IEnumerable<Password> GetAllByProfile(int id) 
        {
            using (PasswordManagerContext context = new PasswordManagerContext())
            {
                List<Password> passwords = new List<Password>();
                List<PasswordEntity> entities = context.Passwords.SqlQuery("SELECT p.* FROM dbo.PasswordEntities p INNER JOIN CategoryEntities c ON p.CategoryEntity_Id = c.Id WHERE p.Profile_id=@id ORDER BY c.Name", new SqlParameter("@id", id)).ToList();
                foreach (PasswordEntity entity in entities)
                {
                    passwords.Add(mapper.EntityToPassword(entity));
                }
                return passwords;
            }
        }

        public IEnumerable<Password> GetPasswordsByStrength(string strength) 
        {
            using (PasswordManagerContext context = new PasswordManagerContext())
            {
                List<Password> passwords = new List<Password>();
                List<PasswordEntity> entities = context.Passwords.SqlQuery("SELECT p.* FROM dbo.PasswordEntities p INNER JOIN CategoryEntities c ON p.CategoryEntity_Id = c.Id WHERE p.Profile_id=@id AND p.Strength=@strength ORDER BY c.Name", new SqlParameter("@id", this.profile.Id), new SqlParameter("@strength",strength)).ToList();
                foreach (PasswordEntity entity in entities)
                {
                    passwords.Add(mapper.EntityToPassword(entity));
                }
                return passwords;
            }
        }

        public IEnumerable<Password> GetAllWithSamePassword(List<Password> passwords) 
        {
            using (PasswordManagerContext context = new PasswordManagerContext())
            {
                List<Password> matchingPasswords = new List<Password>();
                foreach(Password password in passwords) 
                {
                    List<PasswordEntity> entities = context.Passwords.SqlQuery("SELECT p.* FROM dbo.PasswordEntities p INNER JOIN CategoryEntities c ON p.CategoryEntity_Id = c.Id WHERE p.Profile_id=@id AND p.Password=@password ORDER BY c.Name", new SqlParameter("@id", this.profile.Id), new SqlParameter("@password", password.Pass)).ToList();
                    foreach (PasswordEntity entity in entities)
                    {
                        matchingPasswords.Add(mapper.EntityToPassword(entity));
                    }
                }
                return matchingPasswords;
            }
        }
    }
}
