namespace Startup.Exceptions
{
    using System;

    internal class InvalidValueForBoxException : Exception
    {
        private const string message = "Value of box points cannot be lower than 0";

        public InvalidValueForBoxException()
            : base(message)
        {
        }
    }
}