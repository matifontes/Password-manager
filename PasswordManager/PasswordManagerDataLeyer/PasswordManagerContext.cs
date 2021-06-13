using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PasswordManagerDataLeyer
{
    class PasswordManagerContext : DbContext
    {
        public PasswordManagerContext() : base("name=PasswordManagerDB") 
        {
            
        }

        public DbSet<ProfileEntity> Profiles { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<PasswordEntity> Passwords { get; set; }
        public DbSet<CreditCardEntity> CreditCards { get; set; }
        public DbSet<DataBreachEntity> DataBreaches { get; set; }
    }
}
