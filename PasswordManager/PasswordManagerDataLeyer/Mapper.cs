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
    }
}
