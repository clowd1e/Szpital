using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Szpital.Exceptions
{
    public class InvalidPhoneNumberException : Exception
    {
        public InvalidPhoneNumberException()
        {
        }

        public InvalidPhoneNumberException(string? message) : base(message)
        {
        }

        public InvalidPhoneNumberException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidPhoneNumberException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
