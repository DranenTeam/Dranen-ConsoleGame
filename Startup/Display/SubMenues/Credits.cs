using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Startup.Display.SubMenues
{
    public class Credits
    {
        public Credits(int rollSpeed = 250)
        {
            Console.Clear();
            Sound.CreditsSound();

            var cursor = 1;

            for (int i = 0; i < 15; i++)
            {
                Console.Clear();
                Startup.Menu.Position(15, cursor);
                Console.WriteLine(StaticMessages.AuthorsList);
                Thread.Sleep(rollSpeed);
                cursor++;
                if (cursor == Console.WindowHeight)
                {
                    cursor = 1;
                }
            }
            Console.ReadKey(); //TODO: Break the while and go back in the menu
        }
    }
}