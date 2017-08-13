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
        private static int currentScore = 0;

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
                    EventsProcessor(events);
                    cki = MovementProcessor(obj, cki, game);
                    if (game.IsEnd)
                    {
                        ShowEndScreen(stopwatch, game);
                        return;
                    }
                    LiveBoardProcessor(game);
                    HostilesProcessor(obj, events, hostiles, game);
                }

                cki = Console.ReadKey(true);
            }
            while (cki.Key != ConsoleKey.Escape);
        }

        private static ConsoleKeyInfo MovementProcessor(Protagonist obj, ConsoleKeyInfo cki, Game game)
        {
            if (cki.Key == ConsoleKey.UpArrow)
            {
                Move(Direction.Up, obj, game);
            }
            if (cki.Key == ConsoleKey.DownArrow)
            {
                Move(Direction.Down, obj, game);
            }
            if (cki.Key == ConsoleKey.LeftArrow)
            {
                Move(Direction.Left, obj, game);
            }
            if (cki.Key == ConsoleKey.RightArrow)
            {
                Move(Direction.Right, obj, game);
            }
            if (cki.Key == ConsoleKey.Spacebar && !game.IsPaused)
            {
                //&& !Game.IsEnd
                Console.WriteLine("Press UP,DOWN,LEFT or RIGHT to continue.");
                game.Pause();
                cki = Console.ReadKey();
            }

            return cki;
        }

        private static void LiveBoardProcessor(Game game)
        {
            Drawing.ClearBackground();
            Drawing.LivesBoard(game);
        }

        private static void HostilesProcessor(Protagonist obj, List<EventPoint> events, List<Hostile> hostiles, Game game)
        {
            foreach (var hostile in hostiles)
            {
                if (obj.X < hostile.X)
                {
                    ChaseLeft(hostile, obj);
                }
                if (obj.X > hostile.X)
                {
                    ChaseRight(hostile, obj);
                }
                if (obj.Y < hostile.Y)
                {
                    ChaseUp(hostile, obj);
                }
                if (obj.Y > hostile.Y)
                {
                    ChaseDown(hostile, obj);
                }

                Drawing.Events(events);
                Drawing.DrawHostile(hostile);
                Drawing.ScoreBoard(game);

                ProcessEvents(events, obj, hostile, game);
            }

            if (currentScore >= Settings.Game.HostileAddingScore)
            {
                currentScore = 0;
                GenerateHostile(hostiles);
            }
            //if (Game.Score == 0 && hostiles.Count > 1)
            //{
            //    hostiles.Clear();
            //    GenerateHostile(hostiles);
            //}
        }

        private static void EventsProcessor(List<EventPoint> events)
        {
            if (events.Count <= Settings.Game.EventsCount)
            {
                GenerateEvent(events);
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

        private static void GenerateHostile(List<Hostile> hostiles)
        {
            var rnd = new Random();
            var x = rnd.Next(2, (Settings.Environment.WidthConst / 2) - 2) * 2;
            var y = rnd.Next(2, Settings.Environment.HeightConst - 2);
            hostiles.Add(new Hostile(x, y));
        }

        private static void ResetHostile(Hostile hostile)
        {
            hostile.RandomReset();
        }

        private static void GenerateEvent(List<EventPoint> events)
        {
            var rnd = new Random();
            var x = rnd.Next(1, (Settings.Environment.WidthConst / 2) - 3);
            var y = rnd.Next(1, (Settings.Environment.HeightConst / 2) - 2);
            var time = rnd.Next(15, 95);
            EventPoint ev = new EventPoint(x * 2, y * 2, Settings.Environment.WidthConst, Settings.Environment.HeightConst, time);

            events.Add(ev);
        }

        

        private static void ProcessEvents(List<EventPoint> events, Protagonist obj, Hostile hostile, Game game)
        {
            for (int i = 0; i < events.Count; i++)
            {
                if (events[i].Y == obj.Y && events[i].X == obj.X)
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

            if (obj.Y == hostile.Y && obj.X == hostile.X)
            {
                if (game.Lives > 0)
                {
                    game.DecreaseLive();
                    game.AddScore(Settings.Game.LoseLifePenalty);
                    currentScore -= Settings.Game.LoseLifePenalty;
                    ResetHostile(hostile);
                }
                else
                {
                    game.End();
                }
            }
        }

        public static void Move(Direction direction, Protagonist protagonist, Game game)
        {
            if (direction == Direction.Up)
            {
                MoveUp(protagonist);
            }
            if (direction == Direction.Down)
            {
                MoveDown(protagonist);
            }
            if (direction == Direction.Left)
            {
                MoveLeft(protagonist);
            }
            if (direction == Direction.Right)
            {
                MoveRight(protagonist);
            }
            game.UnPause();
        }

        public static void MoveLeft(Protagonist obj)
        {
            obj.Move(-1, 0);
            Drawing.ClearBackground(obj);
        }

        private static void MoveDown(Protagonist obj)
        {
            obj.Move(0, 1);
            Drawing.ClearBackground(obj);
        }

        private static void MoveRight(Protagonist obj)
        {
            obj.Move(1, 0);
            Drawing.ClearBackground(obj);
        }

        private static void MoveUp(Protagonist obj)
        {
            obj.Move(0, -1);
            Drawing.ClearBackground(obj);
        }

        private static void ChaseLeft(Hostile hostile, Protagonist obj)
        {
            hostile.Move(-1, 0);
            Drawing.Draw(hostile, obj);
        }

        private static void ChaseRight(Hostile hostile, Protagonist obj)
        {
            hostile.Move(1, 0);
            Drawing.Draw(hostile, obj);
        }

        private static void ChaseDown(Hostile hostile, Protagonist obj)
        {
            hostile.Move(0, 1);
            Drawing.Draw(hostile, obj);
        }

        private static void ChaseUp(Hostile hostile, Protagonist obj)
        {
            hostile.Move(0, -1);
            Drawing.Draw(hostile, obj);
        }
    }
}