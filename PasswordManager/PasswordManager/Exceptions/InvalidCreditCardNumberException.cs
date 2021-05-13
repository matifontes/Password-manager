using System;

namespace PasswordManager.Exceptions
{
    public class InvalidCreditCardNumberException : Exception
    {
        public InvalidCreditCardNumberException(string message)
            : base(message)
        {
        }
    }
}
