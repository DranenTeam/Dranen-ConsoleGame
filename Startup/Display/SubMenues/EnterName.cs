using System;

namespace Startup.Display.SubMenues
{
    public class EnterName
    {
        private string playersName;

        public EnterName(string message)
        {
            this.playersName = String.Empty;
            while (playersName.Length < 1)
            {
                Console.Clear();
                Display.Menu.Logo();
                Console.SetCursorPosition(11, 11);
                Console.CursorVisible = true;
                Console.CursorSize = 100;
                Console.WriteLine(message);
                Console.SetCursorPosition(15, 13);
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