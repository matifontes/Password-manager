using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManagerDataLeyer
{
    public class CategoryEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ProfileEntity Profile { get; set; }

    }
}
