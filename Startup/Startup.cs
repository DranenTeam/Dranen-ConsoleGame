using Startup.Interfaces;

namespace Startup
{
    public class Program
    {
        private static void Main()
        {
            ISound mySound = new Sound();
            Startup.Menu.Initialize(mySound);
        }
    }
}