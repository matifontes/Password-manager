using System;
using System.Runtime.Serialization;

namespace PasswordManagerDataLeyer
{
    [Serializable]
    class ProfileAlreadyExistsExeption : Exception
    {
        public ProfileAlreadyExistsExeption()
        {
        }

        public ProfileAlreadyExistsExeption(string message) : base(message)
        {
        }

        public ProfileAlreadyExistsExeption(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ProfileAlreadyExistsExeption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}