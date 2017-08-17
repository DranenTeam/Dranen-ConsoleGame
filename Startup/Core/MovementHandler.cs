using Startup.Display;
using Startup.Enums;
using Startup.Interfaces;
using System;

namespace Startup.Core
{
    public class MovementHandler
    {
        public void Navigate(IDynamic obj, ConsoleKeyInfo cki, Game game)
        {
            switch (cki.Key)
            {
                case ConsoleKey.UpArrow:
                    Move(Direction.Up, obj, game);
                    break;

                case ConsoleKey.DownArrow:
                    Move(Direction.Down, obj, game);
                    break;

                case ConsoleKey.LeftArrow:
                    Move(Direction.Left, obj, game);
                    break;

                case ConsoleKey.RightArrow:
                    Move(Direction.Right, obj, game);
                    break;

                case ConsoleKey.Spacebar:
                    if (!game.IsPaused)
                    {
                        Console.WriteLine(StaticMessages.GamePause);
                        game.Pause();
                        cki = Console.ReadKey();
                    }
                    break;
            }
        }

        private void Move(Direction direction, IDynamic agent, Game game)
        {
            switch (direction)
            {
                case Direction.Up:
                    agent.Move(0, -1);
                    break;

                case Direction.Down:
                    agent.Move(0, 1);
                    break;

                case Direction.Left:
                    agent.Move(-1, 0);
                    break;

                case Direction.Right:
                    agent.Move(1, 0);
                    break;
            }
            game.UnPause();
        }
    }
}