namespace Startup.Settings
{
    using Startup.Exceptions;

    public class Game
    {
        public const int EventsCount = 25; // Count of Point boxes on the map [5 - 50]
        private static int gameSpeed = 30;
        private static int pointDeductor = 1; // How much points a point box losses every game tick [ 1-5 ]
        private static int pointEventGoodScore = 50;
        private static int pointEventBestScore = 70;
        private static int hostileAddingScore = 50; // after how mutch points generated a new hostile is added
        private static int loseLifePenalty = -100;
        private static int lifes = 3;

        public static int Lifes
        {
            get { return lifes; }
            set
            {
                if (value > 0)
                {
                    pointDeductor = value;
                }
                else
                {
                    throw new InvalidLiveCountException();
                }
            }
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
                    throw new InvalidGameSpeedException();
                }
            }
        }

        public static int PointDeductor
        {
            get
            {
                return pointDeductor;
            }
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
                return pointEventBestScore;
            }
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
                    throw new InvalidHostileAddingScoreException();
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
                    throw new InvalidLoseLifePenalty();
                }
            }
        }
    }
}