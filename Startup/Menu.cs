using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using Dranen;
using Startup.Core;

namespace Startup
{
    public static class Menu
    {
        public static void Initialize()
        {
            Sound.GameStartSound();
            //Console.WindowHeight =20;
            //Console.WindowWidth = 40;
            //Console.BufferHeight = 20;
            //Console.BufferWidth = 40;
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
                Console.Clear();
                Logo();
                Position(11, 11);
                Console.CursorVisible = true;
                Console.CursorSize = 100;
                Console.WriteLine("What is your name?");
                Position(15, 13);
                StringBuilder playersName = new StringBuilder(Console.ReadLine());

                Sound.MenuEffect();
                while (true)
                {
                    Console.Clear();
                    Console.CursorVisible = false;
                    Logo();
                    Position(16, 7);
                    Console.WriteLine($"Hello {playersName}!");
                    Position(10, 8);
                    Console.WriteLine($"Good luck in your quest!");
                    var position = 11;
                    foreach (var item in menuList)
                    {
                        if (position == cursor)
                        {
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                        Position(16, position);
                        Console.WriteLine(item);
                        position++;

                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    var key = Console.ReadKey();
                    Sound.MenuEffect();
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
                                    Game(playersName.ToString());
                                    break;

                                case 12:
                                    Options();
                                    break;

                                case 13:
                                    HowToPlay();
                                    break;

                                case 14:
                                    Credits();
                                    break;

                                case 15:
                                    Exit();
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

        //public static void PlayersName(StringBuilder playersName)
        //{
        //    playersName = new StringBuilder(2, 10);
        //}

        private static void Position(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }

        public static void Logo()
        {
            Console.WriteLine(@"

    ____
   |    \  ___  ___  ___  ___  ___
   |  |  ||  _|| -_||   || -_||   |
   |____/ |_|  |___||_|_||___||_|_|
   ");
        }

        private static void Credits()
        {
            Console.Clear();
            Sound.CreditsSound();
            const string text = "Drenen 2017\nTheo Dor\nNikoleta Valchinova\nVladimir Gadjov\nKostadin Valchev\nDimitar Nikolov"; // dev names or something about the game.

            var cursor = 1;

            for (int i = 0; i < 15; i++)
            {
                Console.Clear();
                Position(15, cursor);
                Console.WriteLine(text);
                Thread.Sleep(250);
                cursor++;
                if (cursor == Console.WindowHeight)
                {
                    cursor = 1;
                }
            }

            Console.ReadKey(); //TODO: Break the while and go back in the menu
        }

        private static void HowToPlay()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine(@"
1. Chase the points
2. Dodge the red hostiles
3. Repeat");
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }

        private static void Options()
        {
            var optionsList = new[]
            {
                "Game Speed Normal"//, "option2", "option3", "option4", "option5"
            };
            var cursor = 11;

            while (true)
            {
                Console.Clear();
                Logo();

                var position = 11;
                foreach (var item in optionsList)
                {
                    if (position == cursor)
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    Position(11, position);
                    Console.WriteLine(item);
                    Sound.MenuEffect();
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
            var optValue = string.Empty;
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

        private static void Exit()
        {
            Environment.Exit(0);
        }

        public static void Game(string playerName)
        {
            while (true)
            {
                InitializeEnvironment();
                Game game = new Game(3);
                game.PlayersName = playerName;

                Protagonist protagonist = new Protagonist();
                List<Event> events = new List<Event>();
                List<Hostile> hostiles = new List<Hostile>();
                hostiles.Add(new Hostile(4, 4));
                //Navigation navigation = new Navigation(protagonist, events, hostiles, game);
                Engine engine = new Engine(protagonist, events, hostiles, game);
                ConsoleKeyInfo cki = new ConsoleKeyInfo();
                Stopwatch stopwatch = new Stopwatch();
                engine.NavigateProtagonist(cki, stopwatch);
            }
        }

        private static void InitializeEnvironment()
        {
            Console.CursorVisible = false;
            Console.BufferHeight = Settings.Environment.Height;
            Console.BufferWidth = Settings.Environment.Width;
            Console.SetWindowSize(Settings.Environment.Width, Settings.Environment.Height);
            Console.BackgroundColor = Settings.Color.Background;
            Console.Clear();
            Console.BackgroundColor = Settings.Color.Protagonist;
            Console.SetCursorPosition(0, 0);
            Console.Write("  ");
        }
    }
}