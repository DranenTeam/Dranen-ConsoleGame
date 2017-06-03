using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dranen
{
    public static class GameParameter
    {
        private static int gameSpeed = 10;
        private static bool isPaused = false;

        public static bool IsPaused
        {
            get { return isPaused; }
            set { isPaused = value; }
        }

        public static int GameSpeed
        {
            get { return gameSpeed; }
            set
            {
                if (value > 0)
                {
                    gameSpeed = value;
                }
            }
        }

        public const int WidthConst = 80; // This should not be less than the visible area of your console
        public const int HeightConst = 30;
        public static ConsoleColor BackgroundColor = ConsoleColor.DarkGreen;
        public static ConsoleColor ProtagonistColor = ConsoleColor.Black;
    }
}
