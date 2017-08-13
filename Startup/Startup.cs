using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dranen;
using Startup;

namespace Dranen
{
    public class Program
    {
        private static void Main()
        {
            Menu.Initialize();
        }

        public static void Game()
        {
            while (true)
            {
                InitializeGame();
                Dranen.Game.Score = 0;
                Protagonist protagonist = new Protagonist(Settings.Environment.WidthConst, Settings.Environment.HeightConst);

                List<EventPoint> events = new List<EventPoint>();
                List<Hostile> hostiles = new List<Hostile>();
                hostiles.Add(new Hostile(4, 4));
                Navigation.NavigateProtagonist(protagonist, events, hostiles);
            }
        }

        private static void InitializeGame()
        {
            Console.CursorVisible = false;
            Console.BufferHeight = Settings.Environment.HeightConst;
            Console.BufferWidth = Settings.Environment.WidthConst;
            Console.SetWindowSize(Settings.Environment.WidthConst, Settings.Environment.HeightConst);
            Console.BackgroundColor = Settings.Color.Background;
            Console.Clear();
            Console.BackgroundColor = Settings.Color.Protagonist;
            Console.SetCursorPosition(0, 0);
            Console.Write("  ");
        }
    }
}