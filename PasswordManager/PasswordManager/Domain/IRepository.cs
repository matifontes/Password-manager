using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
    public interface IRepository<T>
    {
        void Add(T entity);
        bool IsEmpty();
        T Get(int Id);
        IEnumerable<T> GetAll();
        void Delete(int id);
        void Update(T entity);
    }
}
