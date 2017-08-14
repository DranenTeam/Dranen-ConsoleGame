namespace Startup.Settings
{
    using System;
    using Startup.Exceptions;

    public class Game
    {
        public const int EventsCount = 10; // Count of Point boxes on the map [5 - 50]
        private int gameSpeed = 30;
        private int pointDeductor = 1; // How much points a point box losses every game tick [ 5-99]
        private int pointEventGoodScore = 50; // Above that points a box is colored as good [ 5-99]
        private int pointEventBestScore = 70;// Above that points a box is colored as best [ 5-99]
        private int hostileAddingScore = 500; // after how mutch points generated a new hostile is added
        private int loseLifePenalty = -100;

        public int GameSpeed
        {
            get { return this.gameSpeed; }
            set
            {
                if (value > 0)
                {
                    this.gameSpeed = value;
                }
                else
                {
                    throw new ArgumentException("Game speed cannot be lower than 0");
                }
            }
        }

        public int PointDeductor
        {
            get
            {
                return this.pointDeductor; }
            set
            {
                if (value > 0)
                {
                    this.pointDeductor = value;
                }
                else
                {
                    throw new InvalidValueForBoxException();
                }
            }
        }

        public int PointEventGoodScore
        {
            get { return this.pointEventGoodScore; }
            set
            {
                if (value > 0)
                {
                    this.pointEventGoodScore = value;
                }
                else
                {
                    throw new InvalidValueForBoxException();
                }
            }
        }

        public int PointEventBestScore
        {
            get
            {
                return this.pointEventBestScore; }
            set
            {
                if (value > 0)
                {
                    this.pointEventBestScore = value;
                }
                else
                {
                    throw new InvalidValueForBoxException();
                }
            }
        }

        public int HostileAddingScore
        {
            get
            {
                return this.hostileAddingScore;
            }
            set
            {
                if (value > 0)
                {
                    this.hostileAddingScore = value;
                }
                else
                {
                    throw new ArgumentException("Score must be more then 0 for new hostile to be added.");
                }
            }
        }

        public int LoseLifePenalty
        {
            get { return this.loseLifePenalty; }
            set
            {
                if (value < 0)
                {
                    this.loseLifePenalty = value;
                }
                else
                {
                    throw new ArgumentException("Penalty should be a negative number.");
                }
            }
        }
    }
}