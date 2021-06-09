using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManager;

namespace PasswordManagerDataLeyer.RepositoriesDB
{
    public class ProfileRepository : IRepository<Profile,int>
    {
        private Mapper mapper = new Mapper();

        public void Add(Profile profile) 
        {
            using (PasswordManagerContext context = new PasswordManagerContext()) 
            {
                if (context.Profiles.Any(p => p.Id == profile.Id)) 
                {
                    throw new ProfileAlreadyExistsExeption();
                }

                ProfileEntity entity = mapper.ProfileToEntity(profile);
                context.Profiles.Add(entity);
                context.SaveChanges();
                profile.Id = entity.Id;
            }
        }

        public bool IsEmpty()
        {
            using (PasswordManagerContext context = new PasswordManagerContext())
            {
                return context.Profiles.Count() == 0;
            }
        }

        public Profile Get(int id) 
        {
            using (PasswordManagerContext context = new PasswordManagerContext()) 
            {
                ProfileEntity entity = context.Profiles.Find(id);
                if (entity == null) 
                {
                    throw new ProfileNotFoundExeption();
                }

                Profile profile = mapper.EntityToProfile(entity);
                return profile;
            }
        }

        public IEnumerable<Profile> GetAll() 
        {
            List<Profile> profiles = new List<Profile>();

            using (PasswordManagerContext context = new PasswordManagerContext())
            { 
                foreach(ProfileEntity entity in context.Profiles.ToList()) 
                {
                    profiles.Add(mapper.EntityToProfile(entity));
                }
            }
            return profiles;
        }

        public void Delete(int id)
        {
            using (PasswordManagerContext context = new PasswordManagerContext())
            {
                ProfileEntity entity = context.Profiles.Find(id);
                if (entity == null) 
                {
                    throw new ProfileNotFoundExeption();
                }

                context.Profiles.Remove(entity);
                context.SaveChanges();
            }
        }

        public void Update(Profile profile) 
        {
            using (PasswordManagerContext context = new PasswordManagerContext())
            {
                ProfileEntity entity = context.Profiles.Find(profile.Id);
                if (entity == null)
                {
                    throw new ProfileNotFoundExeption();
                }
                entity.Password = profile.Password;
                context.SaveChanges();
            }
        }
    }
}
