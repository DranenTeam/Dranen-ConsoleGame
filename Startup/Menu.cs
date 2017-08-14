using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using Startup.Core;
using Startup.Models;

namespace Startup
{
    public static class Menu
    {
        public static void Initialize()
        {
            Sound.GameStartSound();
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
                Display.Menu.Logo();
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
                    Display.Menu.Logo();

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
                                    Display.Menu.StartGame(playersName.ToString());
                                    break;

                                case 12:
                                    Display.Menu.Options();
                                    break;

                                case 13:
                                    Display.Menu.HowToPlay();
                                    break;

                                case 14:
                                    Display.Menu.Credits();
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

        public static void Position(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }

        private static void Exit()
        {
            Environment.Exit(0);
        }
    }
}