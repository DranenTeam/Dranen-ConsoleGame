using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Startup.Models;

namespace Startup.Core
{
    public class Engine
    {
        private Protagonist protagonist;
        private List<Event> events;
        private List<Hostile> hostiles;
        private Game game;
        private MovementHandler movementHandler;
        private EventsProcessor eventsProcessor;
        private HostilesProcessor hostilesProcessor;

        public Engine(Protagonist protagonist, List<Event> events, List<Hostile> hostiles, Game game, MovementHandler movementHandler, EventsProcessor eventsProcessor, HostilesProcessor hostilesProcessor)
        {
            this.protagonist = protagonist;
            this.events = events;
            this.hostiles = hostiles;
            this.game = game;
            this.movementHandler = movementHandler;
            this.eventsProcessor = eventsProcessor;
            this.hostilesProcessor = hostilesProcessor;
        }

        public void NavigateProtagonist(ConsoleKeyInfo cki, Stopwatch stopwatch)
        {
            // tests
            do
            {
                // if no key is pressed (or hold) execute the last key pressed command every [Settings.Game.GameSpeed] seconds
                while (Console.KeyAvailable == false)
                {
                    // starts game time counter
                    stopwatch.Start();

                    // pause the environment for some time( THIS REPRESENTS ONE GAME LOOP !!! )
                    Thread.Sleep(Settings.Game.GameSpeed);

                    // creates new events if needed
                    this.eventsProcessor.Run();

                    // execute last movement command till key is pressed
                    this.movementHandler.Navigate(this.protagonist, cki, this.game);

                    if (this.game.IsEnd)
                    {
                        // TODO: Refacotr this via event or somethig
                        Display.Menu.EndScreen(stopwatch, this.game);
                        return;
                    }

                    // Draws the screen
                    Display.Board.ClearBackground();
                    Display.Information.LivesBoard(this.game);

                    this.hostilesProcessor.Run();
                    this.eventsProcessor.ProcessEventsAndGetScores(this.protagonist, this.game);
                    this.hostilesProcessor.ProcessHostilesAndGetScores(this.protagonist, this.game);

                    Display.Board.All(this.hostiles, this.protagonist, this.events);
                    Display.Information.ScoreBoard(this.game);
                }

                // Reads another key
                cki = Console.ReadKey(true);
            }
            while (cki.Key != ConsoleKey.Escape);
        }
    }
}