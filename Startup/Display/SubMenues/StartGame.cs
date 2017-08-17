using Startup.Core;
using Startup.Interfaces;
using Startup.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Startup.Display.SubMenues
{
    public class StartGame
    {
        public StartGame(string playerName)
        {
            while (true)
            {
                InitializeEnvironment();
                Random randomGenerator = new Random();
                Game game = new Game(Settings.Game.Lifes);
                game.PlayersName = playerName;
                Menu menu = new Menu();
                Protagonist protagonist = new Protagonist();
                List<GameEvent> events = new List<GameEvent>();
                List<IHostile> hostiles = new List<IHostile>();
                hostiles.Add(new Hostile(4, 4));
                MovementHandler movementHandler = new MovementHandler();
                EventsProcessor eventsProcessor = new EventsProcessor(events, randomGenerator);
                HostilesProcessor hostilesProcessor = new HostilesProcessor(hostiles, game);
                Display.Board board = new Board();
                Display.Information information = new Information();
                Engine engine = new Engine(protagonist, events, hostiles, game, movementHandler, eventsProcessor, hostilesProcessor, board, information, menu);
                ConsoleKeyInfo cki = new ConsoleKeyInfo();
                Stopwatch stopwatch = new Stopwatch();
                engine.Start(cki, stopwatch);
            }
        }

        private void InitializeEnvironment()
        {
            Console.CursorVisible = false;
            Console.BufferHeight = Settings.Environment.Height;
            Console.BufferWidth = Settings.Environment.Width;
            Console.SetWindowSize(Settings.Environment.Width, Settings.Environment.Height);
            Console.BackgroundColor = Settings.Color.Background;
            Console.Clear();
            Console.BackgroundColor = Settings.Color.Protagonist;
            Console.SetCursorPosition(0, 0);
            Console.Write("  ");
        }
    }
}