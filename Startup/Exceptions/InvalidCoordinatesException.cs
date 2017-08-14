using System;

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