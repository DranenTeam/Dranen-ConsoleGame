using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Mime;
using System.Threading;
using Dranen;
using Startup;

namespace Dranen
{
    public class Navigation
    {
        public enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }

        public static void NavigateProtagonist(Protagonist obj, List<EventPoint> events, List<Hostile> hostiles)
        {
            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            Stopwatch stopwatch = new Stopwatch();

            do
            {
                while (Console.KeyAvailable == false)
                {
                    stopwatch.Start();
                    Thread.Sleep(Game.GameSpeed);
                    EventsProcessor(events);
                    cki = MovementProcessor(obj, cki);
                    if (Game.IsEnd)
                    {
                        ShowEndScreen(stopwatch);
                        Game.IsEnd = false;
                        Game.Lives = 3;
                        return;
                    }
                    LiveBoardProcessor();
                    HostilesProcessor(obj, events, hostiles);
                }

                cki = Console.ReadKey(true);

            }
            while (cki.Key != ConsoleKey.Escape);

        }

        private static ConsoleKeyInfo MovementProcessor(Protagonist obj, ConsoleKeyInfo cki)
        {
            if (cki.Key == ConsoleKey.UpArrow)
            {
                Move(Direction.Up, obj);
            }
            if (cki.Key == ConsoleKey.DownArrow)
            {
                Move(Direction.Down, obj);
            }
            if (cki.Key == ConsoleKey.LeftArrow)
            {
                Move(Direction.Left, obj);
            }
            if (cki.Key == ConsoleKey.RightArrow)
            {
                Move(Direction.Right, obj);
            }
            if (cki.Key == ConsoleKey.Spacebar && !Game.IsPaused )
            {
                //&& !Game.IsEnd
                Console.WriteLine("Press UP,DOWN,LEFT or RIGHT to continue.");
                Game.IsPaused = true;
                cki = Console.ReadKey();
            }

            return cki;
        }

        private static void LiveBoardProcessor()
        {
            Drawing.ClearBackground();
            Drawing.LivesBoard();
        }

        private static void HostilesProcessor(Protagonist obj, List<EventPoint> events, List<Hostile> hostiles)
        {
            foreach (var hostile in hostiles)
            {
                if (hostile.IsAlive && obj.X < hostile.X)
                {
                    ChaseLeft(hostile, obj);
                }
                if (hostile.IsAlive && obj.X > hostile.X)
                {
                    ChaseRight(hostile, obj);
                }
                if (hostile.IsAlive && obj.Y < hostile.Y)
                {
                    ChaseUp(hostile, obj);
                }
                if (hostile.IsAlive && obj.Y > hostile.Y)
                {
                    ChaseDown(hostile, obj);
                }

                Drawing.Events(events);
                Drawing.DrawHostile(hostile);
                Drawing.ScoreBoard();

                ProcessEvents(events, obj, hostile);
            }

            if (currentScore >= Game.HostileAddingScore)
            {
                currentScore = 0;
                GenerateHostile(hostiles);
            }
            if (Game.Score <= 0 && hostiles.Count > 1)
            {
                hostiles.Clear();
                GenerateHostile(hostiles);
            }
        }

        private static void EventsProcessor(List<EventPoint> events)
        {
            if (events.Count <= Game.EventsCount)
            {
                GenerateEvent(events);
            }
        }

        private static void ShowEndScreen(Stopwatch stopwatch)
        {
            Console.Clear();
            Menu.Logo();
            stopwatch.Stop();
            Console.SetCursorPosition(9, 10);
            Console.WriteLine($"Sorry {Game.PlayersName}, You died! :(");
            Console.SetCursorPosition(10, 12);
            Console.WriteLine($"Time: {stopwatch.Elapsed.TotalSeconds.ToString("0")}");
            Console.SetCursorPosition(10, 13);
            Console.WriteLine($"Score: {Game.Score}");
            Console.SetCursorPosition(9, 15);
            Console.WriteLine($"Prss any key to start over.");
            if (true)
            {
                Thread.Sleep(2000);
                Console.ReadKey();
            }
        }

        private static void GenerateHostile(List<Hostile> hostiles)
        {
            var rnd = new Random();
            var x = rnd.Next(2, (Game.WidthConst / 2) - 2) * 2;
            var y = rnd.Next(2, Game.HeightConst - 2);
            hostiles.Add(new Hostile(x, y));

        }

        private static void ResetHostile(Hostile hostile)
        {
            hostile.RandomReset();
        }


        private static void GenerateEvent(List<EventPoint> events)
        {
            var rnd = new Random();
            var x = rnd.Next(1, Game.WidthConst / 2 - 3);
            var y = rnd.Next(1, Game.HeightConst / 2 - 2);
            var time = rnd.Next(15, 95);
            EventPoint ev = new EventPoint(x * 2, y * 2, time);
            events.Add(ev);
        }

        private static int currentScore = 0;

        private static void ProcessEvents(List<EventPoint> events, Protagonist obj, Hostile hostile)
        {
            for (int i = 0; i < events.Count; i++)
            {
                if (events[i].Y == obj.Y && events[i].X == obj.X)
                {
                    Game.Score += events[i].Points;
                    currentScore += events[i].Points;
                    events[i].Points = 0;
                }

                if (events[i].Points <= Game.PointDeathThreshold)
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
                if (Game.Lives > 0)
                {
                    Game.Lives--;
                    Game.Score -= 100;
                    currentScore -= 100;
                    ResetHostile(hostile);
                }
                else
                {
                    Game.IsEnd = true;
                }
            }
        }

        public static void Move(Direction direction, Protagonist protagonist)
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
            Game.IsPaused = false;
        }

        public static void MoveLeft(Protagonist obj)
        {
            obj.Move(-1, 0);
            Drawing.DrawProtagonist(obj);
            Drawing.ClearBackground(obj);
        }

        private static void MoveDown(Protagonist obj)
        {
            obj.Move(0, 1);
            Drawing.DrawProtagonist(obj);
            Drawing.ClearBackground(obj);
        }

        private static void MoveRight(Protagonist obj)
        {
            obj.Move(1, 0);
            Drawing.DrawProtagonist(obj);
            Drawing.ClearBackground(obj);
        }

        private static void MoveUp(Protagonist obj)
        {
            obj.Move(0, -1);
            Drawing.DrawProtagonist(obj);
            Drawing.ClearBackground(obj);
        }

        private static void ChaseLeft(Hostile hostile, Protagonist obj)
        {
            hostile.Chase(-1, 0);
            Drawing.DrawHostile(hostile);
            Drawing.Draw(hostile, obj);
        }

        private static void ChaseRight(Hostile hostile, Protagonist obj)
        {
            hostile.Chase(1, 0);
            Drawing.DrawHostile(hostile);
            Drawing.Draw(hostile, obj);
        }

        private static void ChaseDown(Hostile hostile, Protagonist obj)
        {
            hostile.Chase(0, 1);
            Drawing.DrawHostile(hostile);
            Drawing.Draw(hostile, obj);
        }

        private static void ChaseUp(Hostile hostile, Protagonist obj)
        {
            hostile.Chase(0, -1);
            Drawing.DrawHostile(hostile);
            Drawing.Draw(hostile, obj);
        }
    }
}
