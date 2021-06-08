using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PasswordManagerDataLeyer
{
    public class CreditCardEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Number { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public short CCVCode { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Note { get; set; }
        public ProfileEntity Profile { get; set; }
    }
}
