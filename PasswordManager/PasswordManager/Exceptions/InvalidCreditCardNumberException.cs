using System;

namespace PasswordManager
{
    public class InvalidCreditCardNumberException : Exception
    {
        public InvalidCreditCardNumberException(string message)
            : base(message)
        {
        }
    }
}
