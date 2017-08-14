using Startup.Display;

namespace Startup.Core
{
    public class LiveBoardProcessor
    {
        public static void Run(Game game)
        {
            Board.ClearBackground();
            Display.Information.LivesBoard(game);
        }
    }
}