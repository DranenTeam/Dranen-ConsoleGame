namespace Startup.Exceptions
{
    using System;

    internal class InvalidGameSpeedException : Exception
    {
        private const string message = "Game speed cannot be lower than 0";

        public InvalidGameSpeedException()
            : base(message)
        {
        }
    }
}