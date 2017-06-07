using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dranen
{
    public static class Game
    {
        private static int gameSpeed = 10;
        private static bool isPaused = false;
        private static int score = 0;

        public static int Score
        {
            get { return score; }
            set { score = value; }
        }


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
                else
                {
                    throw new ArgumentException("Game speed cannot be lower than 0");
                }
            }
        }

        public const int WidthConst = 80; // This should not be less than the visible area of your console
        public const int HeightConst = 30;
        public static ConsoleColor BackgroundColor = ConsoleColor.DarkGray;
        public static ConsoleColor ProtagonistColor = ConsoleColor.Black;
        public static ConsoleColor PointEventColorBest = ConsoleColor.DarkGreen;
        public static ConsoleColor PointEventColorGood = ConsoleColor.DarkYellow;
        public static ConsoleColor PointEventColorBad = ConsoleColor.DarkRed;
        public static ConsoleColor HostileColor = ConsoleColor.Red;
        public const int EventsCount = 5;
    }
}
