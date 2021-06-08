using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManagerDataLeyer
{
    public class PasswordEntity
    {
        public int Id { get; set; }
        public string Site { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Note { get; set; }
        public string Strength { get; set; }
        public DateTime LastModificationDate { get; set; }
        public ProfileEntity Profile {get; set;}
    }
}
