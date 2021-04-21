using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
    public class Password
    {
        public Category Category { get; set; }
        public string Pass { get; set; }
        public string Site { get; set; }
        public string User { get; set; }
        public string Note { get; set; }
        public DateTime LastModificationDate { get; set; }

        public Password(Category category, string password, string site, string user, string note)
        {
            this.Category = category;
            this.Pass = password;
            this.Site = site;
            this.User = user;
            this.Note = note;
            this.LastModificationDate = DateTime.Today;
        }
    }
}
