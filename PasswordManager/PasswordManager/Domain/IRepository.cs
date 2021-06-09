using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
    public interface IRepository<T,K>
    {
        void Add(T entity);
        bool IsEmpty();
        T Get(K Id);
        IEnumerable<T> GetAll();
        void Delete(K id);
        void Update(T entity);
    }
}
