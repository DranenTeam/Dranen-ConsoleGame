using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Net.Mime;
using System.Threading;
using Dranen;
using Startup.Enums;
using Startup;
using Settings;

namespace Dranen
{
    public class Navigation
    {
        private int currentScore = 0;
        private Protagonist protagonist;
        private IList<PointBox> events;
        private IList<Hostile> hostiles;
        private Game game;

        public Navigation(Protagonist protagonist, List<PointBox> events, List<Hostile> hostiles, Game game)
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
                    EventsProcessor();
                    cki = MovementProcessor(cki);
                    if (game.IsEnd)
                    {
                        ShowEndScreen(stopwatch, game);
                        return;
                    }
                    LiveBoardProcessor();
                    HostilesProcessor();
                }

                cki = Console.ReadKey(true);
            }
            while (cki.Key != ConsoleKey.Escape);
        }

        private ConsoleKeyInfo MovementProcessor(ConsoleKeyInfo cki)
        {
            if (cki.Key == ConsoleKey.UpArrow)
            {
                Move(Direction.Up);
            }
            if (cki.Key == ConsoleKey.DownArrow)
            {
                Move(Direction.Down);
            }
            if (cki.Key == ConsoleKey.LeftArrow)
            {
                Move(Direction.Left);
            }
            if (cki.Key == ConsoleKey.RightArrow)
            {
                Move(Direction.Right);
            }
            if (cki.Key == ConsoleKey.Spacebar && !this.game.IsPaused)
            {
                //&& !Game.IsEnd
                Console.WriteLine("Press UP,DOWN,LEFT or RIGHT to continue.");
                this.game.Pause();
                cki = Console.ReadKey();
            }

            return cki;
        }

        private void LiveBoardProcessor()
        {
            Drawing.ClearBackground();
            Drawing.LivesBoard(this.game);
        }

        private void HostilesProcessor()
        {
            foreach (var hostile in this.hostiles)
            {
                if (this.protagonist.X < hostile.X)
                {
                    ChaseLeft(hostile);
                }
                if (this.protagonist.X > hostile.X)
                {
                    ChaseRight(hostile);
                }
                if (protagonist.Y < hostile.Y)
                {
                    ChaseUp(hostile);
                }
                if (protagonist.Y > hostile.Y)
                {
                    ChaseDown(hostile);
                }

                Drawing.Events(events);
                Drawing.DrawHostile(hostile);
                Drawing.ScoreBoard(game);

                ProcessEvents(hostile);
            }

            if (currentScore >= Settings.Game.HostileAddingScore)
            {
                currentScore = 0;
                GenerateHostile(hostiles);
            }
        }

        private void EventsProcessor()
        {
            if (this.events.Count <= Settings.Game.EventsCount)
            {
                GenerateEvent(this.events);
            }
        }

        private static void ShowEndScreen(Stopwatch stopwatch, Game game)
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

        private static void GenerateHostile(IList<Hostile> hostiles)
        {
            var rnd = new Random();
            var x = rnd.Next(2, (Settings.Environment.Width / 2) - 2) * 2;
            var y = rnd.Next(2, Settings.Environment.Height - 2);
            hostiles.Add(new Hostile(x, y));
        }

        private static void ResetHostile(Hostile hostile)
        {
            hostile.RandomReset();
        }

        private static void GenerateEvent(IList<PointBox> events)
        {
            var rnd = new Random();
            var x = rnd.Next(1, (Settings.Environment.Width / 2) - 3);
            var y = rnd.Next(1, (Settings.Environment.Height / 2) - 2);
            var time = rnd.Next(15, 95);
            PointBox ev = new PointBox(x * 2, y * 2, time);

            events.Add(ev);
        }

        private void ProcessEvents(Hostile hostile)
        {
            for (int i = 0; i < events.Count; i++)
            {
                if (events[i].Y == this.protagonist.Y && this.events[i].X == this.protagonist.X)
                {
                    this.game.AddScore(this.events[i].Points);
                    this.currentScore += this.events[i].Points;
                    this.events[i].Points = 0;
                    Sound.Event();
                }

                if (this.events[i].Points <= Settings.Game.PointDeathThreshold)
                {
                    this.events.RemoveAt(i);
                }
                else
                {
                    this.events[i].Deduct();
                }
            }

            if (this.protagonist.Y == hostile.Y && this.protagonist.X == hostile.X)
            {
                if (this.game.Lives > 0)
                {
                    this.game.DecreaseLive();
                    this.game.AddScore(Settings.Game.LoseLifePenalty);
                    this.currentScore -= Settings.Game.LoseLifePenalty;
                    ResetHostile(hostile);
                }
                else
                {
                    this.game.End();
                }
            }
        }

        private void Move(Direction direction)
        {
            if (direction == Direction.Up)
            {
                MoveUp();
            }
            if (direction == Direction.Down)
            {
                MoveDown();
            }
            if (direction == Direction.Left)
            {
                MoveLeft();
            }
            if (direction == Direction.Right)
            {
                MoveRight();
            }
            this.game.UnPause();
        }

        private void MoveLeft()
        {
            this.protagonist.Move(-1, 0);
            Drawing.ClearBackground(this.protagonist);
        }

        private void MoveDown()
        {
            this.protagonist.Move(0, 1);
            Drawing.ClearBackground(this.protagonist);
        }

        private void MoveRight()
        {
            this.protagonist.Move(1, 0);
            Drawing.ClearBackground(this.protagonist);
        }

        private void MoveUp()
        {
            this.protagonist.Move(0, -1);
            Drawing.ClearBackground(this.protagonist);
        }

        private void ChaseLeft(Hostile hostile)
        {
            hostile.Move(-1, 0);
            Drawing.Draw(hostile, this.protagonist);
        }

        private void ChaseRight(Hostile hostile)
        {
            hostile.Move(1, 0);
            Drawing.Draw(hostile, this.protagonist);
        }

        private void ChaseDown(Hostile hostile)
        {
            hostile.Move(0, 1);
            Drawing.Draw(hostile, this.protagonist);
        }

        private void ChaseUp(Hostile hostile)
        {
            hostile.Move(0, -1);
            Drawing.Draw(hostile, this.protagonist);
        }
    }
}