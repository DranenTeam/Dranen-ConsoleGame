using System;

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