using System;

namespace Startup.Exceptions
{
    public class InvalidLiveCountException : Exception

    {
        private const string message = "Game cannot be started with negative lives!";

        public InvalidLiveCountException()
            : base(message)
        {
        }
    }
}