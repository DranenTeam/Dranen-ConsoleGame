using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Startup;

namespace Dranen
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    internal class Program
    {

        static void Main()
        {
            Game();
        }

        private static void Game()
        {
            Protagonist protagonist = new Protagonist();
            InitializeGame();
            NavigateProtagonist(protagonist);
        }

        private static void NavigateProtagonist(Protagonist obj)
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

        private static void Move(Direction direction, Protagonist protagonist)
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

        private static void MoveLeft(Protagonist obj)
        {
            obj.Move(-1, 0);
            DrawProtagonist(obj);
            ClearBackground(obj);
        }

        private static void MoveDown(Protagonist obj)
        {
            obj.Move(0, 1);
            DrawProtagonist(obj);
            ClearBackground(obj);
        }

        private static void MoveRight(Protagonist obj)
        {
            obj.Move(1, 0);
            DrawProtagonist(obj);
            ClearBackground(obj);
        }

        private static void MoveUp(Protagonist obj)
        {
            obj.Move(0, -1);
            DrawProtagonist(obj);
            ClearBackground(obj);
        }

        private static void DrawProtagonist(Protagonist obj)
        {
            Console.BackgroundColor = GameParameter.ProtagonistColor;
            Console.SetCursorPosition(obj.X, obj.Y);
            if (obj.Y == 0 || obj.X == 0)
            {
                Console.Write("..");
            }
            else
            {
                Console.Write("  ");
            }

        }

        private static void DrawPlayground(Protagonist obj)
        {
            for (int i = 0; i < GameParameter.WidthConst; i += 20)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("  ");
                Console.SetCursorPosition(i, GameParameter.HeightConst - 1);
                Console.Write("  ");
            }

            for (int i = 0; i < GameParameter.HeightConst; i += 10)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("  ");
                Console.SetCursorPosition(GameParameter.WidthConst - 2, i);
                Console.Write("  ");
            }
            Console.SetCursorPosition(obj.X, obj.Y);
        }

        private static void ClearBackground(Protagonist obj)
        {
            Console.BackgroundColor = GameParameter.BackgroundColor;
            Console.Clear();
            DrawProtagonist(obj);
            DrawPlayground(obj);

        }

        private static void InitializeGame()
        {
            Console.CursorVisible = false;
            Console.BufferHeight = GameParameter.HeightConst;
            Console.BufferWidth = GameParameter.WidthConst;
            Console.SetWindowSize(GameParameter.WidthConst, GameParameter.HeightConst);
            Console.BackgroundColor = GameParameter.BackgroundColor;
            Console.Clear();
            Console.BackgroundColor = GameParameter.ProtagonistColor;
            Console.SetCursorPosition(0, 0);
            Console.Write("  ");

        }
    }
}
