using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Exceptions
{
    public class InvalidPasswordNoteException : Exception
    {
        public InvalidPasswordNoteException()
        {

        }
        public InvalidPasswordNoteException(string message)
            : base(message)
        {
        }
    }
}
