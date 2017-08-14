using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startup.Display.SubMenues
{
    public class HowToPlay
    {
        public HowToPlay()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine(StaticMessages.HowToPlayInstructions);
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }
    }
}