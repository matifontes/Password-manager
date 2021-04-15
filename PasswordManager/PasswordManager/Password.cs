using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
    public class Password
    {
        public Categorie Categorie { get; set; }
        public string Pass { get; set; }
        public string Site { get; set; }
        public string User { get; set; }
        public string Note { get; set; }
        public Password(Categorie categorie, string password, string site, string user, string note)
        {
            this.Categorie = categorie;
            this.Pass = password;
            this.Site = site;
            this.User = user;
            this.Note = note;
        }
    }
}
