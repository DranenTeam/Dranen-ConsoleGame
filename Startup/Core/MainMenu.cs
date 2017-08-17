using Startup.Constants;
using Startup.Display;
using Startup.Interfaces;
using System;

namespace Startup
{
    public class MainMenu
    {
        private ISoundable sound;
        private Menu menu;

        public MainMenu()
        {
            this.sound = new Soundable();
            this.menu = new Menu();
        }

        public void Initialize()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            this.sound.MakeSound(FileSoundPath.GameStartSound);
            Console.WindowHeight = Settings.Environment.Height;
            Console.WindowWidth = Settings.Environment.Width;
            Console.BufferHeight = Settings.Environment.Height;
            Console.BufferWidth = Settings.Environment.Width;
            Console.CursorVisible = false;
            var menuList = new string[]
            {
                "Play", "Options", "How to play", "Credits", "Exit"
            };
            var cursor = 11;

            while (true)
            {
                menu.EnterName();
                this.sound.MakeSound(FileSoundPath.MenuEffect);
                while (true)
                {
                    menu.Greeting();
                    var position = 11;
                    foreach (var item in menuList)
                    {
                        if (position == cursor)
                        {
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                        Console.SetCursorPosition(16, position);
                        Console.WriteLine(item);
                        position++;

                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    var key = Console.ReadKey();
                    this.sound.MakeSound(FileSoundPath.MenuEffect);
                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:
                            cursor--;
                            break;

                        case ConsoleKey.DownArrow:
                            cursor++;
                            break;

                        case ConsoleKey.Enter:
                            switch (cursor)
                            {
                                case 11:
                                    menu.StartGame(menu.Result);
                                    break;

                                case 12:
                                    menu.Options();
                                    break;

                                case 13:
                                    menu.HowToPlay();
                                    break;

                                case 14:
                                    menu.Credits();
                                    break;

                                case 15:
                                    menu.Exit();
                                    break;
                            }
                            break;
                            //case ConsoleKey.Escape: return;
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
        }
    }
}