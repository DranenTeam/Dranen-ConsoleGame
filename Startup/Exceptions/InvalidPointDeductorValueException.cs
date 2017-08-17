using System;

namespace Startup.Exceptions
{
    public class InvalidPointDeductorValueException : Exception
    {
        private const string message = "PointDeductor must be positive";

        public InvalidPointDeductorValueException()
             : base(message)
        {
        }
    }
}