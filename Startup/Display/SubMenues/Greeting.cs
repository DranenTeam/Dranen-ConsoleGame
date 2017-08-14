using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startup.Display.SubMenues
{
    public class Greeting
    {
        public Greeting()
        {
            Console.Clear();
            Console.CursorVisible = false;
            Display.Menu.Logo();
            Startup.Menu.Position(16, 7);
            Console.WriteLine($"Hello {Display.Menu.Result}!");
            Startup.Menu.Position(10, 8);
            Console.WriteLine($"Good luck in your quest!");
        }
    }
}