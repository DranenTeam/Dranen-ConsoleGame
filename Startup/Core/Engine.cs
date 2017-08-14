using Dranen;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Startup.Commands;

namespace Startup.Core
{
    public class Engine
    {
        private int currentScore = 0;
        private Protagonist protagonist;
        private List<PointBox> events;
        private List<Hostile> hostiles;
        private Game game;

        public Engine(Protagonist protagonist, List<PointBox> events, List<Hostile> hostiles, Game game)
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
                while (Console.KeyAvailable == false)
                {
                    stopwatch.Start();
                    Thread.Sleep(Settings.Game.GameSpeed);
                    EventsProcessor.Run(events);
                    cki = MovementProcessor.Run(protagonist, cki, game);
                    if (game.IsEnd)
                    {
                        ShowEndScreen.Run(stopwatch, game);
                        return;
                    }
                    LiveBoardProcessor.Run(game);
                    HostilesProcessor();
                }

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

                Drawing.Events(this.events);
                Drawing.DrawHostile(hostile);
                Drawing.ScoreBoard(game);

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
                if (events[i].Y == this.protagonist.Y && events[i].X == this.protagonist.X)
                {
                    game.AddScore(events[i].Points);
                    currentScore += events[i].Points;
                    events[i].Points = 0;
                    Sound.Event();
                }

                if (events[i].Points <= Settings.Game.PointDeathThreshold)
                {
                    events.RemoveAt(i);
                }
                else
                {
                    events[i].Deduct();
                }
            }
        }

        private void ChaseLeft(Hostile hostile, Protagonist obj)
        {
            hostile.Move(-1, 0);
            Drawing.Draw(hostile, obj);
        }

        private void ChaseRight(Hostile hostile, Protagonist obj)
        {
            hostile.Move(1, 0);
            Drawing.Draw(hostile, obj);
        }

        private void ChaseDown(Hostile hostile, Protagonist obj)
        {
            hostile.Move(0, 1);
            Drawing.Draw(hostile, obj);
        }

        private void ChaseUp(Hostile hostile, Protagonist obj)
        {
            hostile.Move(0, -1);
            Drawing.Draw(hostile, obj);
        }
    }
}