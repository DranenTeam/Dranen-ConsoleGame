using System;
using System.Collections.Generic;
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
        public static void NavigateProtagonist(Protagonist obj, List<EventPoint> events, Hostile hostile)
        {


            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            GenerateHostile(hostile);
            do
            {

                while (Console.KeyAvailable == false)
                {
                    Thread.Sleep(Game.GameSpeed);
                    if (events.Count <= Game.EventsCount)
                    {
                        GenerateEvent(events);
                    }



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
                    if (cki.Key == ConsoleKey.Spacebar && !Game.IsPaused)
                    {
                        Console.WriteLine("Press UP,DOWN,LEFT or RIGHT to continue");
                        Game.IsPaused = true;
                        cki = Console.ReadKey();

                    }

                    if (hostile.IsAlive && obj.X <= 15)
                    {
                        ChaseLeft(hostile, obj);
                    }

                    if (hostile.IsAlive && obj.X >= 15)
                    {
                        ChaseRight(hostile, obj);
                    }

                    if (hostile.IsAlive && obj.Y <= 14)
                    {
                        ChaseUp(hostile, obj);
                    }

                    if (hostile.IsAlive && obj.Y >= 14)
                    {
                        ChaseDown(hostile, obj);
                    }

                    Drawing.Events(events);
                    Drawing.DrawHostile(hostile);
                    Drawing.ScoreBoard();
                    ProcessEvents(events, obj, hostile);
                }

                cki = Console.ReadKey(true);

            } while (cki.Key != ConsoleKey.Escape);
        }

        private static void GenerateHostile(Hostile hostiles)
        {
            var rnd = new Random();
            var x = rnd.Next(3, Game.WidthConst - 3);
            var y = rnd.Next(2, Game.HeightConst - 2);
            //var hostile = new Hostile(x, y);
            //hostiles.Add(hostile);
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

        private static void ProcessEvents(List<EventPoint> events, Protagonist obj, Hostile hostile)
        {
            for (int i = 0; i < events.Count; i++)
            {
                if (events[i].Y == obj.Y && events[i].X == obj.X)
                {
                    Game.Score += events[i].Points;
                    events[i].Points = 0;
                }

                if (events[i].Points <= Game.PointDeathThreshold)
                {
                    events.RemoveAt(i);
                }
            }

            if (obj.Y == hostile.Y && obj.X == hostile.X)
            {
                Game.Score = 0;
            }

            foreach (var ev in events)
            {
                ev.Deduct();
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
            Drawing.ClearBackground(hostile, obj);
        }

        private static void ChaseRight(Hostile hostile, Protagonist obj)
        {
            hostile.Chase(1, 0);
            Drawing.DrawHostile(hostile);
            Drawing.ClearBackground(hostile, obj);
        }

        private static void ChaseDown(Hostile hostile, Protagonist obj)
        {
            hostile.Chase(0, 1);
            Drawing.DrawHostile(hostile);
            Drawing.ClearBackground(hostile, obj);
        }

        private static void ChaseUp(Hostile hostile, Protagonist obj)
        {
            hostile.Chase(0, -1);
            Drawing.DrawHostile(hostile);
            Drawing.ClearBackground(hostile, obj);
        }
    }
}
