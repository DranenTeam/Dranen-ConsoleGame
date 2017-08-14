using Dranen;
using Startup.Enums;
using System;
using Startup.Interfaces;

namespace Startup.Core
{
    public class MovementProcessor
    {
        public static void Run(IDynamic obj, ConsoleKeyInfo cki, Game game)
        {
            if (cki.Key == ConsoleKey.UpArrow)
            {
                Navigation.Move(Direction.Up, obj, game);
            }
            if (cki.Key == ConsoleKey.DownArrow)
            {
                Navigation.Move(Direction.Down, obj, game);
            }
            if (cki.Key == ConsoleKey.LeftArrow)
            {
                Navigation.Move(Direction.Left, obj, game);
            }
            if (cki.Key == ConsoleKey.RightArrow)
            {
                Navigation.Move(Direction.Right, obj, game);
            }
            if (cki.Key == ConsoleKey.Spacebar && !game.IsPaused)
            {
                Console.WriteLine("Press UP,DOWN,LEFT or RIGHT to continue.");
                game.Pause();
                cki = Console.ReadKey();
            }
        }
    }
}