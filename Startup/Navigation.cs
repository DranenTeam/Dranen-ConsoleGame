using System;
using System.Collections.Generic;
using System.Threading;
using Dranen;

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
        public static void NavigateProtagonist(Protagonist obj, List<EventPoint> events)
        {


            ConsoleKeyInfo cki = new ConsoleKeyInfo();
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
                    Drawing.Events(events);
                    ProcessEvents(events);
                }

                cki = Console.ReadKey(true);

            } while (cki.Key != ConsoleKey.Escape);
        }

        private static void GenerateEvent(List<EventPoint> events)
        {
            var rnd = new Random();
            var x = rnd.Next(3, Game.WidthConst - 3);
            var y = rnd.Next(2, Game.HeightConst - 2);
            var time = rnd.Next(500, 5000);
            EventPoint ev = new EventPoint(x, y, time);
            events.Add(ev);
        }

        private static void ProcessEvents(List<EventPoint> events)
        {
            for (int i = 0; i < events.Count; i++)
            {
                if (events[i].Points <= 10)
                {
                    events.RemoveAt(i);
                }
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
    }
}
