using Startup.Display.SubMenues;
using System.Diagnostics;

namespace Startup.Display
{
    public class Menu // Sort of factory
    {
        private string result;
        private string playerName;
        private StaticMessages staticMessages;

        public void EnterName()
        {
            this.staticMessages = new StaticMessages();
            var menuForm = new EnterName(this.staticMessages.EnterNameQuestion);
            this.Result = menuForm.PlayersName;
            this.playerName = menuForm.PlayersName;
        }

        public string Result
        {
            get { return this.result; }
            private set { this.result = value; }
        }

        public void Credits()
        {
            new Credits(this.staticMessages.AuthorsList);
        }

        public void HowToPlay()
        {
            new HowToPlay(this.staticMessages.HowToPlayInstructions);
        }

        public void Options()
        {
            new Options();
        }

        public void StartGame(string playerName)
        {
            new StartGame(playerName);
        }

        public void Greeting()
        {
            new Greeting(this.playerName, this.staticMessages.GoodLuck);
        }

        public void EndScreen(Stopwatch stopwatch, Game game)
        {
            new EndScreen(stopwatch, game);
        }

        public void Exit()
        {
            new Exit();
        }

        // :(
        public static void Logo()
        {
            new Logo();
        }
    }
}