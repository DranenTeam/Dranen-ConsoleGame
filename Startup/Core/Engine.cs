using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Startup.Core.Commands;
using Startup.Display;
using Startup.Interfaces;
using Startup.Models;

namespace Startup.Core
{
    public class Engine
    {
        private int currentScore = 0;
        private Protagonist protagonist;
        private List<Event> events;
        private List<Hostile> hostiles;
        private Game game;

        public Engine(Protagonist protagonist, List<Event> events, List<Hostile> hostiles, Game game)
        {
            this.currentScore = 0;
            this.protagonist = protagonist;
            this.events = events;
            this.hostiles = hostiles;
            this.game = game;
        }

        public void NavigateProtagonist(ConsoleKeyInfo cki, Stopwatch stopwatch)
        {
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
                    EventsProcessor.Run(this.events);

                    // execute last movement command
                    MovementProcessor.Run(this.protagonist, cki, this.game);
                    if (this.game.IsEnd)
                    {
                        // TODO: Refacotr this via event or somethig
                        Display.Menu.EndScreen(stopwatch, this.game);
                        return;
                    }

                    // Draws the screen
                    Display.Board.ClearBackground();
                    Display.Information.LivesBoard(this.game);

                    HostilesProcessor(); // draws
                }

                // Reads another key
                cki = Console.ReadKey(true);
            }
            while (cki.Key != ConsoleKey.Escape);
        }

        public void HostilesProcessor()
        {
            foreach (var hostile in this.hostiles)
            {
                if (this.protagonist.X < hostile.X)
                {
                    hostile.Move(-1, 0);
                }
                if (this.protagonist.X > hostile.X)
                {
                    hostile.Move(1, 0);
                }
                if (this.protagonist.Y < hostile.Y)
                {
                    hostile.Move(0, -1);
                }
                if (this.protagonist.Y > hostile.Y)
                {
                    hostile.Move(0, 1);
                }

                if (this.protagonist.Y == hostile.Y && this.protagonist.X == hostile.X)
                {
                    if (this.game.Lives > 0)
                    {
                        this.game.DecreaseLive();

                        this.game.AddScore(Settings.Game.LoseLifePenalty);
                        this.currentScore -= Settings.Game.LoseLifePenalty;
                        ResetHostile.Execute(hostile);
                    }
                    else
                    {
                        game.End();
                    }
                }

                Display.Board.Agent(hostile, Settings.Color.Hostile);
                this.ProcessEvents();
            }
            Display.Board.Agent(this.protagonist, Settings.Color.Protagonist);

            Display.Board.Events(this.events);
            Display.Information.ScoreBoard(this.game);

            if (this.currentScore >= Settings.Game.HostileAddingScore)
            {
                this.currentScore = 0;
                GenerateHostile.Execute(this.hostiles);
            }
        }

        private void ProcessEvents()
        {
            for (int i = 0; i < events.Count; i++)
            {
                var currentEvent = this.events[i];
                if (currentEvent.Y == this.protagonist.Y && currentEvent.X == this.protagonist.X)
                {
                    var points = currentEvent.Activate();
                    this.game.AddScore(points);
                    this.currentScore += points;
                    Sound.Event();
                }
                currentEvent.TimeTrigger();
                if (!currentEvent.IsActive)
                {
                    this.events.RemoveAt(i);
                }
            }
        }
    }
}