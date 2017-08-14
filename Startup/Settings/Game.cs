using System;

namespace Startup.Settings
{
    public static class Game
    {
        public const int EventsCount = 10; // Count of Point boxes on the map [5 - 50]
        private static int gameSpeed = 30;
        private static int pointDeductor = 1; // How much points a point box losses every game tick [ 5-99]
        private static int pointEventGoodScore = 50; // Above that points a box is colored as good [ 5-99]

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

        public static int PointDeductor
        {
            get { return pointDeductor; }
            set
            {
                if (value > 0)
                {
                    pointDeductor = value;
                }
                else
                {
                    throw new ArgumentException("Value of box points cannot be lower than 0");
                }
            }
        }

        public static int PointEventGoodScore
        {
            get { return pointEventGoodScore; }
            set
            {
                if (value > 0)
                {
                    pointEventGoodScore = value;
                }
                else
                {
                    throw new ArgumentException("Value of box points cannot be lower than 0");
                }
            }
        }

        public static int PointEventBestScore = 70;// Above that points a box is colored as best [ 5-99]
        public static int HostileAddingScore = 500; // after how mutch points generated a new hostile is added
        public static int LoseLifePenalty = -100;
    }
}