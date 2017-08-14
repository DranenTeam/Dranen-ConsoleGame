using System;

namespace Startup.Display.SubMenues
{
    public class EnterName
    {
        private string playersName;

        public EnterName()
        {
            this.playersName = String.Empty;
            while (playersName.Length < 1)
            {
                Console.Clear();
                Display.Menu.Logo();
                Startup.Menu.Position(11, 11);
                Console.CursorVisible = true;
                Console.CursorSize = 100;
                Console.WriteLine(StaticMessages.EnterNameQuestion);
                Startup.Menu.Position(15, 13);
                this.PlayersName = Console.ReadLine();
            }
        }

        public string PlayersName
        {
            get { return this.playersName; }
            private set { this.playersName = value; }
        }
    }
}