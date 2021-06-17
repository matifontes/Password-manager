using System;
using System.Runtime.Serialization;

namespace PasswordManagerDataLeyer
{
    [Serializable]
    public class ProfileNotFoundException : Exception
    {
        public ProfileNotFoundException()
        {
        }

        public ProfileNotFoundException(string message) : base(message)
        {
        }

        public ProfileNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ProfileNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}