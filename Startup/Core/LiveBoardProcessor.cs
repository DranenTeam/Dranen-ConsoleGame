using Dranen;

namespace Startup.Core
{
    public class LiveBoardProcessor
    {
        public static void Run(Game game)
        {
            Draw.ClearBackground();
            Draw.LivesBoard(game);
        }
    }
}