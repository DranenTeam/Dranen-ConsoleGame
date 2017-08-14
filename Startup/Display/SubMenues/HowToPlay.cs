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
                Console.WriteLine(@"
1. Chase the points
2. Dodge the red hostiles
3. Repeat");
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }
    }
}