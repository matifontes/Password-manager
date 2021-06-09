using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManager;

namespace PasswordManagerDataLeyer.RepositoriesDB
{
    public class PasswordRepository : IRepository<Password>
    {
        private Mapper mapper = new Mapper();
        public void Add(Password password) 
        {
            
        }
        public bool IsEmpty() 
        {
            return false;
        }
        public Password Get(int Id) 
        {
            return null;
        }
        public IEnumerable<Password> GetAll() 
        {
            return null;
        }
        public void Delete(int id) 
        {

        }
        public void Update(Password password) 
        {
        }
    }
}
