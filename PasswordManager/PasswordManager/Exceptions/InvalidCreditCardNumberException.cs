using System;

namespace PasswordManager
{
    public class InvalidCreditCardNumberException : Exception
    {
        public InvalidCreditCardNumberException()
        {

        }
        public InvalidCreditCardNumberException(string message)
            : base(message)
        {
        }
    }
}
