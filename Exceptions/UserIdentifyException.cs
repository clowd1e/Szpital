using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Szpital.Exceptions
{
    public class UserIdentifyException : Exception
    {
        public UserIdentifyException()
        {
        }

        public UserIdentifyException(string? message) : base(message)
        {
        }

        public UserIdentifyException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UserIdentifyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
