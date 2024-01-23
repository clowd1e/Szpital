using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Szpital.Exceptions
{
    public class InvalidOldPasswordException : Exception
    {
        public InvalidOldPasswordException()
        {
        }

        public InvalidOldPasswordException(string? message) : base(message)
        {
        }

        public InvalidOldPasswordException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidOldPasswordException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
