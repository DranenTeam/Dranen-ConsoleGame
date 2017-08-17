using Startup.Display;
using Startup.Interfaces;
using Startup.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Startup.Core
{
    public class Engine
    {
        private Protagonist protagonist;
        private List<GameEvent> events;
        private List<IHostile> hostiles;
        private Game game;
        private MovementHandler movementHandler;
        private EventsProcessor eventsProcessor;
        private HostilesProcessor hostilesProcessor;
        private Board board;
        private Information information;
        private Menu menu;

        public Engine(Protagonist protagonist, List<GameEvent> events, List<IHostile> hostiles, Game game, MovementHandler movementHandler, EventsProcessor eventsProcessor, HostilesProcessor hostilesProcessor, Board board, Information information, Menu menu)
        {
            this.protagonist = protagonist;
            this.events = events;
            this.hostiles = hostiles;
            this.game = game;
            this.movementHandler = movementHandler;
            this.eventsProcessor = eventsProcessor;
            this.hostilesProcessor = hostilesProcessor;
            this.board = board;
            this.information = information;
            this.menu = menu;
        }

        public void Start(ConsoleKeyInfo cki, Stopwatch stopwatch)
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
                        menu.EndScreen(stopwatch, this.game);
                        return;
                    }

                    // Draws the screen
                    this.board.ClearBackground();
                    this.information.LivesBoard(this.game);

                    this.hostilesProcessor.Run();
                    this.eventsProcessor.ProcessEventsAndGetScores(this.protagonist, this.game);
                    this.hostilesProcessor.ProcessHostilesAndGetScores(this.protagonist, this.game);

                    this.board.All(this.hostiles, this.protagonist, this.events);
                    this.information.ScoreBoard(this.game);
                }

                // Reads another key
                cki = Console.ReadKey(true);
            }
            while (cki.Key != ConsoleKey.Escape);
        }
    }
}