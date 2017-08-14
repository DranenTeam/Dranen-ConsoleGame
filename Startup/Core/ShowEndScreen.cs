using System;
using System.Diagnostics;
using System.Threading;

namespace Startup.Core
{
    public class ShowEndScreen
    {
        public static void Run(Stopwatch stopwatch, Game game)
        {
            Console.Clear();
            Menu.Logo();
            stopwatch.Stop();
            Console.SetCursorPosition(9, 10);
            Console.WriteLine($"Sorry {game.PlayersName}, You died! :(");
            Console.SetCursorPosition(10, 12);
            Console.WriteLine($"Time: {stopwatch.Elapsed.TotalSeconds.ToString("0")}");
            Console.SetCursorPosition(10, 13);
            Console.WriteLine($"Score: {game.Score}");
            Console.SetCursorPosition(9, 15);
            Console.WriteLine($"Prss any key to start over.");
            Sound.GameOver();

            if (true)
            {
                Thread.Sleep(2000);
                Console.ReadKey();
            }
        }
    }
}