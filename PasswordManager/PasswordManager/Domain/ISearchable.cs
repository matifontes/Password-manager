using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
    public interface ISearchable<T>
    {
        IEnumerable<T> GetAllByProfile(int id);
    }
}
