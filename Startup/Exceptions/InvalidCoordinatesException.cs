using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startup.Exceptions
{
    public class InvalidCoordinatesException : Exception
    {
        public InvalidCoordinatesException(string message)
             : base(message)
        {
        }
    }
}