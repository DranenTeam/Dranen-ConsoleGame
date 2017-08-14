using Startup.Display.SubMenues;
using System.Diagnostics;
using System.Media;

namespace Startup.Display
{
    public static class Menu // Sort of factory
    {
        private static string result;

        public static string Result
        {
            get { return result; }
            private set { result = value; }
        }

        public static void EnterName()
        {
            var instance = new EnterName();
            Result = instance.PlayersName;
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

        public static void Greeting()
        {
            new Greeting();
        }

        public static void EndScreen(Stopwatch stopwatch, Game game)
        {
            new EndScreen(stopwatch, game);
        }

        public static void Exit()
        {
            new Exit();
        }
    }
}