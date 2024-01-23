using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Szpital.Exceptions
{
    public class InvalidNewPasswordException : Exception
    {
        public InvalidNewPasswordException()
        {
        }

        public InvalidNewPasswordException(string? message) : base(message)
        {
        }

        public InvalidNewPasswordException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidNewPasswordException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
