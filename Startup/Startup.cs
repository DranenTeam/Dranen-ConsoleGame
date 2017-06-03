using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dranen;

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
            InitializeGame();
            Movement.NavigateProtagonist(protagonist);
        }

        private static void InitializeGame()
        {
            Console.CursorVisible = false;
            Console.BufferHeight = GameParameter.HeightConst;
            Console.BufferWidth = GameParameter.WidthConst;
            Console.SetWindowSize(GameParameter.WidthConst, GameParameter.HeightConst);
            Console.BackgroundColor = GameParameter.BackgroundColor;
            Console.Clear();
            Console.BackgroundColor = GameParameter.ProtagonistColor;
            Console.SetCursorPosition(0, 0);
            Console.Write("  ");

        }
    }
}
