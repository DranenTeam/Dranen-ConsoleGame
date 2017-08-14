using System;

namespace Startup.Exceptions
{
    public class InvalidLivesCountException : Exception
    {
        private const string message = "Game cannot be started  with less than 1 live";

        public InvalidLivesCountException()
             : base(message)
        {
        }
    }
}