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

    internal class Program
    {

        static void Main()
        {
            Game();
        }

        private static void Game()
        {
            Protagonist protagonist = new Protagonist();
            List<EventPoint> events = new List<EventPoint>();
            Hostile hostile = new Hostile(5, 5);
            InitializeGame();
            Navigation.NavigateProtagonist(protagonist, events, hostile);
        }

        private static void InitializeGame()
        {
            Console.CursorVisible = false;
            Console.BufferHeight = Dranen.Game.HeightConst;
            Console.BufferWidth = Dranen.Game.WidthConst;
            Console.SetWindowSize(Dranen.Game.WidthConst, Dranen.Game.HeightConst);
            Console.BackgroundColor = Dranen.Game.BackgroundColor;
            Console.Clear();
            Console.BackgroundColor = Dranen.Game.ProtagonistColor;
            Console.SetCursorPosition(0, 0);
            Console.Write("  ");

        }
    }
}
