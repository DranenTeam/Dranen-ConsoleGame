using Startup.Models;

namespace Startup.Core.Commands
{
    public class ResetHostile
    {
        public static void Execute(Hostile hostile)
        {
            hostile.RandomReset();
        }
    }
}