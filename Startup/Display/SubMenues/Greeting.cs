using System;

namespace Startup.Display.SubMenues
{
    public class Greeting
    {
        public Greeting(string name, string message)
        {
            Console.Clear();
            Console.CursorVisible = false;
            Display.Menu.Logo();
            Console.SetCursorPosition(16, 7);
            Console.WriteLine($"Hello {name}!");
            Console.SetCursorPosition(10, 8);
            Console.WriteLine(message);
        }
    }
}