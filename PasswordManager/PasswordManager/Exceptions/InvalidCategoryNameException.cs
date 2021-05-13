using System;

namespace PasswordManager.Exceptions
{
    public class InvalidCategoryNameException : Exception
    {
        public InvalidCategoryNameException(string message)
            : base(message)
        { 
        }
    }
}