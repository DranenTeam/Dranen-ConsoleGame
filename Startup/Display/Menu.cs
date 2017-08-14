using Startup.Display.SubMenues;
using System.Diagnostics;
using System.Media;

namespace Startup.Display
{
    public static class Menu
    {
        public static void EndScreen(Stopwatch stopwatch, Game game)
        {
            new EndScreen(stopwatch, game);
        }

        public static void Logo()
        {
            new Logo();
        }

        public static void Credits()
        {
            new Credits();
        }

        public static void HowToPlay()
        {
            new HowToPlay();
        }

        public static void Options()
        {
            new Options();
        }

        public static void StartGame(string playerName)
        {
            new StartGame(playerName);
        }
    }
}