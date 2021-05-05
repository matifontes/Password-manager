using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Exceptions
{
    public class InvalidPasswordSiteException : Exception
    {
        public InvalidPasswordSiteException(string message)
            : base(message)
        {
        }
    }
}
