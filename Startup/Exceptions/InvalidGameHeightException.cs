using System;

namespace Startup.Exceptions
{
    public class InvalidGameHeightException : Exception
    {
        private const string message = "Invalid game size, game window height must be higher than 2";


        public InvalidGameHeightException()
            : base(message)
        {
        }
    }
}
