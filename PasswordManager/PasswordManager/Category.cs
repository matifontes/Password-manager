using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
    public class Category
    {
        public string Name {
            get { return Name; }
            private set 
            {
                if (value.Length > 15 || value.Length < 3) {
                    throw new InvalidCategoryNameException();
                }
            } 
        }
        
        public Category(string name)
        {
            this.Name = name;
        }
    }
}
