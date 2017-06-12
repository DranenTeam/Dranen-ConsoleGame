using System;
using System.Text;
using System.Threading;
using Dranen;

namespace Startup
{
    public static class Menu
    {
        public static void Initialize()
        {
            Console.WindowHeight =
                20;
            Console.WindowWidth = 40;
            Console.BufferHeight = 20;
            Console.BufferWidth = 40;
            Console.CursorVisible = false;

            var menuList = new string[]
            {
                "Play", "Options", "How to play", "Credits", "Exit"
            };
            var cursor = 11;
            var position = 11;

            while (true)
            {
                Console.Clear();
                Logo();
                Position(11, position);
                Console.CursorVisible = true;
                Console.CursorSize = 100;
                Console.WriteLine("What is your name?");
                Position(15, 13);
                StringBuilder playersName = new StringBuilder(Console.ReadLine());
                PlayersName(playersName);
                
                while (true)
                {
                    Console.Clear();
                    Console.CursorVisible = false;
                    Logo();
                    Position(16, 7);
                    Console.WriteLine($"Hello {playersName}!");
                    Position(10, 8);
                    Console.WriteLine($"Good luck in your quest!");
                    
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
                                    Program.Game();
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

        public static void PlayersName(StringBuilder playersName)
        {
            playersName = new StringBuilder(2, 10);
        }

        private static void Position(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }

        private static void Logo()
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
            const string text = @"Drenen 2017"; // dev names or something about the game.
            var cursor = 1;
            while (true)
            {
                Console.Clear();
                Position(2, cursor);
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
                Console.WriteLine(@"//TODO: Describe movements and rules
Use Esc for back");
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
                "Game Speed Normal", "option2", "option3", "option4", "option5"
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
                                optionsList[0] = GameSpeed(Game.gameSpeed); break;
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
                Game.gameSpeed = 40;
                optValue = "Game Speed Slow";
            }
            else if (speed == 40)
            {
                Game.GameSpeed = 10;
                optValue = "Game Speed Fast";
            }
            else if (speed == 10)
            {
                Game.GameSpeed = 30;
                optValue = "Game Speed Normal";
            }

            return optValue;
        }

        private static void Exit()
        {
            Environment.Exit(0);
        }
    }
}
