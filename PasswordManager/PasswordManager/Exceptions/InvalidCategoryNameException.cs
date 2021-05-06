using System;

namespace PasswordManager
{
    public class InvalidCategoryNameException : Exception
    {
        public InvalidCategoryNameException(string message)
            : base(message)
        { 
        }
    }
}