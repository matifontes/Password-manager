using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManagerDataLeyer
{
    public class CreditCardEntity
    {
        public CreditCardEntity() 
        {
            this.DataBreachEntities = new HashSet<DataBreachEntity>();
        }
        public int Id { get; set; }
        public long Number { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public short CCVCode { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Note { get; set; }
        public ProfileEntity Profile { get; set; }
        public virtual CategoryEntity CategoryEntity { get; set; }
        public virtual ICollection<DataBreachEntity> DataBreachEntities { get; set; }
    }
}
