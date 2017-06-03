using System;
using System.Threading;
using Dranen;

namespace Dranen
{
    public class Movement
    {
        public enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }
        public static void NavigateProtagonist(Protagonist obj)
        {


            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            do
            {

                while (Console.KeyAvailable == false)
                {
                    Thread.Sleep(GameParameter.GameSpeed);
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
                    if (cki.Key == ConsoleKey.Spacebar && !GameParameter.IsPaused)
                    {
                        Console.WriteLine("Press UP,DOWN,LEFT or RIGHT to continue");
                        GameParameter.IsPaused = true;
                        cki = Console.ReadKey();

                    }
                }

                cki = Console.ReadKey(true);

            } while (cki.Key != ConsoleKey.Escape);
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
            GameParameter.IsPaused = false;
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
