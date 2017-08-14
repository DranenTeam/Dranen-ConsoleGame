using Dranen;

namespace Startup.Core
{
    public class LiveBoardProcessor
    {
        public static void Run(Game game)
        {
            Drawing.ClearBackground();
            Drawing.LivesBoard(game);
        }
    }
}
