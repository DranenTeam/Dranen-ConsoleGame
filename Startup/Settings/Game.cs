namespace Startup.Settings
{
    using System;
    using Startup.Exceptions;

    public class Game
    {
        public const int EventsCount = 10; // Count of Point boxes on the map [5 - 50]
        private static int gameSpeed = 30;
        private static int pointDeductor = 1; // How much points a point box losses every game tick [ 5-99]
        private static int pointEventGoodScore = 50; // Above that points a box is colored as good [ 5-99]
        private static int pointEventBestScore = 70;// Above that points a box is colored as best [ 5-99]
        private static int hostileAddingScore = 500; // after how mutch points generated a new hostile is added
        private static int loseLifePenalty = -100;

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
            get
            {
                return pointDeductor; }
            set
            {
                if (value > 0)
                {
                    pointDeductor = value;
                }
                else
                {
                    throw new InvalidValueForBoxException();
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
                    throw new InvalidValueForBoxException();
                }
            }
        }

        public static int PointEventBestScore
        {
            get
            {
                return pointEventBestScore; }
            set
            {
                if (value > 0)
                {
                    pointEventBestScore = value;
                }
                else
                {
                    throw new InvalidValueForBoxException();
                }
            }
        }

        public static int HostileAddingScore
        {
            get
            {
                return hostileAddingScore;
            }
            set
            {
                if (value > 0)
                {
                    hostileAddingScore = value;
                }
                else
                {
                    throw new ArgumentException("Score must be more then 0 for new hostile to be added.");
                }
            }
        }

        public static int LoseLifePenalty
        {
            get { return loseLifePenalty; }
            set
            {
                if (value < 0)
                {
                    loseLifePenalty = value;
                }
                else
                {
                    throw new ArgumentException("Penalty should be a negative number.");
                }
            }
        }
    }
}