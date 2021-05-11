using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Exceptions
{
    public class EmptyCreditCardNameException : Exception
    {
        public EmptyCreditCardNameException(string message)
         : base(message)
        {
        }
    }
}
