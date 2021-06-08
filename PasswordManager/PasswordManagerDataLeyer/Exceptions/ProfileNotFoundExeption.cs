using System;
using System.Runtime.Serialization;

namespace PasswordManagerDataLeyer
{
    [Serializable]
    class ProfileNotFoundExeption : Exception
    {
        public ProfileNotFoundExeption()
        {
        }

        public ProfileNotFoundExeption(string message) : base(message)
        {
        }

        public ProfileNotFoundExeption(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ProfileNotFoundExeption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}