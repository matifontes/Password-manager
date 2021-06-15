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
            this.CreditCardEntity = new HashSet<CreditCardEntity>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<PasswordEntity> PasswordsEntity { get; set; }
        public virtual ICollection<CreditCardEntity> CreditCardEntity { get; set; }
        public ProfileEntity Profile { get; set; }
    }
}
