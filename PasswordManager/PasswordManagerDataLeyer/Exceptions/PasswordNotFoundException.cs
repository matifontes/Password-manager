using System;
using System.Runtime.Serialization;

namespace PasswordManagerDataLeyer
{
    [Serializable]
    class PasswordNotFoundException : Exception
    {
        public PasswordNotFoundException()
        {
        }

        public PasswordNotFoundException(string message) : base(message)
        {
        }

        public PasswordNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PasswordNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}