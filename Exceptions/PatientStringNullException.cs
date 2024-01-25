using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Szpital.Exceptions
{
    public class PatientStringNullException : Exception
    {
        public override string Message { get; }
        public string ParamName { get; }
        public PatientStringNullException(string paramName) : base()
        {
            Message = "Pole nie może być puste.";
            ParamName = paramName;
        }
    }
}
