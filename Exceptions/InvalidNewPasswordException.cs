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
        public InvalidNewPasswordException(string? message) : base(message)
        {
        }
    }
}
