using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dranen
{
    public static class Game
    {
        public static int gameSpeed = 30;
        private static bool isPaused = false;
        private static bool isEnd = false;
        private static int lives = 3;
        private static int score = 0;
        private static StringBuilder playersName = new StringBuilder();

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
        public static bool IsEnd
        {
            get { return isEnd; }
            set { isEnd = value; }
        }
        public static int Lives
        {
            get { return lives; }
            set { lives = value; }
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

        public static StringBuilder PlayersName
        {
            get { return playersName; }
            set { playersName = value; }
        }

        public static int PointEventGoodScore = 40;
        public static int PointEventBestScore = 70;
        public static int HostileAddingScore = 500;

        public const int WidthConst = 40; // This should not be less than the visible area of your console
        public const int HeightConst = 20;
        public static ConsoleColor BackgroundColor = ConsoleColor.DarkGray;
        public static ConsoleColor ProtagonistColor = ConsoleColor.Black;
        public static ConsoleColor PointEventColorBest = ConsoleColor.DarkGreen;
        public static ConsoleColor PointEventColorGood = ConsoleColor.DarkYellow;
        public static ConsoleColor PointEventColorBad = ConsoleColor.DarkRed;
        public static ConsoleColor HostileColor = ConsoleColor.Red;
        public static ConsoleColor ScoreBoardColor = ConsoleColor.Magenta;
        public static int PointDeductor = 1;
        public const int EventsCount = 10;
        public static int PointDeathThreshold = 5;
    }
}
