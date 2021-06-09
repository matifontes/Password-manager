using System;
using System.Runtime.Serialization;

namespace PasswordManagerDataLeyer
{
    [Serializable]
    class CategoryAlreadyExistsExeption : Exception
    {
        public CategoryAlreadyExistsExeption()
        {
        }

        public CategoryAlreadyExistsExeption(string message) : base(message)
        {
        }

        public CategoryAlreadyExistsExeption(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CategoryAlreadyExistsExeption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}