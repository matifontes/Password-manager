using System;

namespace PasswordManager
{
    public class FailToValidatePasswordException : Exception
    {
        public FailToValidatePasswordException(string message) 
            :base(message)
        {
        }
    }
}