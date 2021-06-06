using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PasswordManager;

namespace PasswordManagerDataLeyer
{
    class PasswordManagerContext : DbContext
    {
        public PasswordManagerContext() : base("name=PasswordManagerDB") 
        {
            
        }

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Password> Passwords { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }

    }
}
