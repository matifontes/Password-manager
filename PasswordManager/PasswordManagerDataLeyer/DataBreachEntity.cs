using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManagerDataLeyer
{
    public class DataBreachEntity
    {

        public DataBreachEntity() 
        {
            this.PasswordsEntity = new HashSet<PasswordEntity>();
            this.CreditCardEntities = new HashSet<CreditCardEntity>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<PasswordEntity> PasswordsEntity { get; set; }
        public virtual ICollection<CreditCardEntity> CreditCardEntities { get; set; }
        public ProfileEntity Profile { get; set; }
    }
}
