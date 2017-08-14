using Startup.Display;
using Startup.Enums;
using Startup.Interfaces;

namespace Startup.Core
{
    public class Navigation
    {
        public static void Move(Direction direction, IDynamic protagonist, Game game)
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

        private static void MoveLeft(IDynamic obj)
        {
            obj.Move(-1, 0);
            Board.ClearBackground(obj);
        }

        private static void MoveDown(IDynamic obj)
        {
            obj.Move(0, 1);
            Board.ClearBackground(obj);
        }

        private static void MoveRight(IDynamic obj)
        {
            obj.Move(1, 0);
            Board.ClearBackground(obj);
        }

        private static void MoveUp(IDynamic obj)
        {
            obj.Move(0, -1);
            Board.ClearBackground(obj);
        }
    }
}