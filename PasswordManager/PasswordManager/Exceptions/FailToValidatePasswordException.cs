using System;

namespace PasswordManager.Exceptions
{
    public class FailToValidatePasswordException : Exception
    {
        public FailToValidatePasswordException(string message) 
            :base(message)
        {
        }
    }
}