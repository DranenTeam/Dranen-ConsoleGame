using Dranen;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Startup.Commands;
using Startup.Interfaces;

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
                    EventsProcessor.Run(events);

                    // execute last movement command
                    MovementProcessor.Run(this.protagonist, cki, this.game);
                    if (game.IsEnd)
                    {
                        // TODO: Refacotr this via event or somethig
                        ShowEndScreen.Run(stopwatch, game);
                        return;
                    }

                    // Draws the screen
                    LiveBoardProcessor.Run(game);
                    HostilesProcessor();
                }

                // Reads another key
                cki = Console.ReadKey(true);
            }
            while (cki.Key != ConsoleKey.Escape);
        }

        public void HostilesProcessor()
        {
            foreach (var hostile in hostiles)
            {
                if (protagonist.X < hostile.X)
                {
                    ChaseLeft(hostile, protagonist);
                }
                if (protagonist.X > hostile.X)
                {
                    ChaseRight(hostile, protagonist);
                }
                if (protagonist.Y < hostile.Y)
                {
                    ChaseUp(hostile, protagonist);
                }
                if (protagonist.Y > hostile.Y)
                {
                    ChaseDown(hostile, protagonist);
                }
                if (protagonist.Y == hostile.Y && protagonist.X == hostile.X)
                {
                    if (game.Lives > 0)
                    {
                        game.DecreaseLive();

                        game.AddScore(Settings.Game.LoseLifePenalty);
                        currentScore -= Settings.Game.LoseLifePenalty;
                        ResetHostile.Execute(hostile);
                    }
                    else
                    {
                        game.End();
                    }
                }

                Draw.Events(this.events);
                Draw.Agent(hostile, Settings.Color.Hostile);
                Draw.ScoreBoard(game);

                ProcessEvents();
            }

            if (currentScore >= Settings.Game.HostileAddingScore)
            {
                currentScore = 0;
                GenerateHostile.Execute(hostiles);
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

        private void ChaseLeft(IDynamic hostile, IDynamic obj)
        {
            hostile.Move(-1, 0);
            Draw.All(hostile, obj);
        }

        private void ChaseRight(IDynamic hostile, IDynamic obj)
        {
            hostile.Move(1, 0);
            Draw.All(hostile, obj);
        }

        private void ChaseDown(IDynamic hostile, IDynamic obj)
        {
            hostile.Move(0, 1);
            Draw.All(hostile, obj);
        }

        private void ChaseUp(IDynamic hostile, IDynamic obj)
        {
            hostile.Move(0, -1);
            Draw.All(hostile, obj);
        }
    }
}