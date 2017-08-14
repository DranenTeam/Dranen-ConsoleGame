using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Startup.Core;
using Startup.Models;

namespace Startup.Display.SubMenues
{
    public class StartGame
    {
        public StartGame(string playerName)
        {
            while (true)
            {
                int innitialLives = 3;
                InitializeEnvironment();
                Game game = new Game(innitialLives);
                game.PlayersName = playerName;

                Protagonist protagonist = new Protagonist();
                List<Event> events = new List<Event>();
                List<Hostile> hostiles = new List<Hostile>();
                hostiles.Add(new Hostile(4, 4));
                Engine engine = new Engine(protagonist, events, hostiles, game);
                ConsoleKeyInfo cki = new ConsoleKeyInfo();
                Stopwatch stopwatch = new Stopwatch();
                engine.NavigateProtagonist(cki, stopwatch);
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