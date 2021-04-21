using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
    public class Category
    {
        private string _name;
        const int MAX_LENGTH_FOR_VALID_NAME = 15;
        const int MIN_LENGTH_FOR_VALID_NAME = 3;

        public string Name {
            get { return _name; }
            private set 
            {
                if (!IsValidName(value))
                {
                    throw new InvalidCategoryNameException();
                }
                else 
                {
                    this._name = value;
                }
            } 
        }
        
        public Category(string name)
        {
            this.Name = name;
        }

        private bool IsValidName(string name) 
        {
            return (name.Length <= MAX_LENGTH_FOR_VALID_NAME) && (name.Length >= MIN_LENGTH_FOR_VALID_NAME);
        }
    }
}
