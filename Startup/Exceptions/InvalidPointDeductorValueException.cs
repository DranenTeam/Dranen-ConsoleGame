using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startup.Exceptions
{
    public class InvalidPointDeductorValueException : Exception
    {
        public InvalidPointDeductorValueException(string message)
             : base(message)
        {
        }
    }
}