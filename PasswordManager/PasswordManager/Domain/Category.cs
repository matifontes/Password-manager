using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManager.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PasswordManager
{
    public class Category
    {
        private string _name;
        const int MAX_LENGTH_FOR_VALID_NAME = 15;
        const int MIN_LENGTH_FOR_VALID_NAME = 3;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Name {
            get { return _name; }
            private set => ChangeName(value);
        }
        
        public Category(string name)
        {
            this.Name = name;
        }

        public void ChangeName(string name)
        {
            if (!IsValidName(name))
            {
                throw new InvalidCategoryNameException("Largo del nombre de categoria incorrecto");
            }
            else
            {
                this._name = name;
            }
        }

        public bool IsEqual(Category category) 
        {
            return this.Name.ToUpper() == category.Name.ToUpper();
        }

        public override string ToString()
        {
            return this.Name;
        }

        private bool IsValidName(string name) 
        {
            return (name.Length <= MAX_LENGTH_FOR_VALID_NAME) && (name.Length >= MIN_LENGTH_FOR_VALID_NAME);
        }
    }
}
