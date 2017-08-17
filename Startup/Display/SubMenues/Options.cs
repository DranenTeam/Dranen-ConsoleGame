using Startup.Constants;
using Startup.Interfaces;
using System;
using System.Media;

namespace Startup.Display.SubMenues
{
    public class Options : ISoundable
    {
        public Options()
        {
            var optionsList = new[]
            {
                "Game Speed Normal"//, "option2", "option3", "option4", "option5"
            };
            var cursor = 11;

            while (true)
            {
                Console.Clear();
                Menu.Logo();

                var position = 11;
                foreach (var item in optionsList)
                {
                    if (position == cursor)
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    Console.SetCursorPosition(11, position);
                    Console.WriteLine(item);
                    MakeSound(FileSoundPath.MenuEffect);
                    position++;

                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        cursor--; break;
                    case ConsoleKey.DownArrow:
                        cursor++; break;
                    case ConsoleKey.Enter:
                        switch (cursor)
                        {
                            case 11:
                                optionsList[0] = GameSpeed(Settings.Game.GameSpeed); break;
                                //case 12: Option2(); break;
                                //case 13: Option3(); break;
                                //case 14: Option4(); break;
                                //case 14: Option5(); break;
                        }
                        break;

                    case ConsoleKey.Escape: return;
                }
                if (cursor < 11)
                {
                    cursor++;
                }
                if (cursor > 15)
                {
                    cursor--;
                }
            }
        }

        private static string GameSpeed(int speed)
        {
            var optValue = String.Empty;
            if (speed == 30)
            {
                Settings.Game.GameSpeed = 40;
                Settings.Game.HostileAddingScore = 200;
                optValue = "Game Speed Slow";
            }
            else if (speed == 40)
            {
                Settings.Game.GameSpeed = 10;
                Settings.Game.HostileAddingScore = 1000;
                optValue = "Game Speed Fast";
            }
            else if (speed == 10)
            {
                Settings.Game.GameSpeed = 30;
                Settings.Game.HostileAddingScore = 500;
                optValue = "Game Speed Normal";
            }

            return optValue;
        }

        public void MakeSound(string filePath)
        {
            SoundPlayer makeSound = new SoundPlayer(filePath);
            makeSound.Play();
        }
    }
}