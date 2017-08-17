namespace Startup.Exceptions
{
    using System;

    internal class InvalidHostileAddingScoreException : Exception
    {
        private const string message = "Score must be more then 0 for new hostile to be added.";

        public InvalidHostileAddingScoreException()
            : base(message)
        {
        }
    }
}