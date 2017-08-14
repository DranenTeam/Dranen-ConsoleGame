using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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