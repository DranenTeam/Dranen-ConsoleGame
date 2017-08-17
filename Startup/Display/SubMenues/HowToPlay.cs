using System;

namespace Startup.Display.SubMenues
{
    public class HowToPlay
    {
        public HowToPlay(string message)
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine(message);
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }
    }
}