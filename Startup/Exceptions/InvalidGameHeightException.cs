using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
