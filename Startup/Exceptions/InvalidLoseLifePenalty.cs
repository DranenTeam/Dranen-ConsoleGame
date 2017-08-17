namespace Startup.Exceptions
{
    using System;

    internal class InvalidLoseLifePenalty : Exception
    {
        private const string message = "Penalty should be a negative number.";

        public InvalidLoseLifePenalty()
            : base(message)
        {
        }
    }
}