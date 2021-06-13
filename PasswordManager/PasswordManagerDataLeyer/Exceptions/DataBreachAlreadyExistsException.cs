using System;
using System.Runtime.Serialization;

namespace PasswordManagerDataLeyer
{
    [Serializable]
    class DataBreachAlreadyExistsException : Exception
    {
        public DataBreachAlreadyExistsException()
        {
        }

        public DataBreachAlreadyExistsException(string message) : base(message)
        {
        }

        public DataBreachAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DataBreachAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}