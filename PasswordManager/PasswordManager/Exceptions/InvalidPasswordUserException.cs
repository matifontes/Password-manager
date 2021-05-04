using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Exceptions
{
    public class InvalidPasswordUserException : Exception
    {
        public InvalidPasswordUserException()
        {

        }
        public InvalidPasswordUserException(string message)
            : base(message)
        {
        }
    }
}
