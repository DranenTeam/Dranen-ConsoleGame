using Dranen;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Startup.Core
{
    public class Engine
    {
        public static void NavigateProtagonist(Protagonist obj, List<EventPoint> events, List<Hostile> hostiles, Game game)
        {
            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            Stopwatch stopwatch = new Stopwatch();

            do
            {
                while (Console.KeyAvailable == false)
                {
                    stopwatch.Start();
                    Thread.Sleep(Settings.Game.GameSpeed);
                    EventsProcessor.Run(events);
                    cki = MovementProcessor.Run(obj, cki, game);
                    if (game.IsEnd)
                    {
                        ShowEndScreen.Run(stopwatch, game);
                        return;
                    }
                    LiveBoardProcessor.Run(game);
                    Navigation.HostilesProcessor(obj, events, hostiles, game);
                }

                cki = Console.ReadKey(true);
            }
            while (cki.Key != ConsoleKey.Escape);
        }
    }
}
