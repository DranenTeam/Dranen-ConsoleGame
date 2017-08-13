using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Settings
{
    public static class Game
    {
        private static int gameSpeed = 30;

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

        public const int EventsCount = 10; // Count of Point boxes on the map [5 - 50]
        public static int PointDeathThreshold = 5; // Below what amount of points a point box disappears [5 - 50]
        public static int PointDeductor = 1; // How much points a poit box losses every game tick [ 5-99]
        public static int PointEventGoodScore = 50; // Above that points a box is colored as good [ 5-99]
        public static int PointEventBestScore = 70;// Above that points a box is colored as best [ 5-99]
        public static int HostileAddingScore = 500; // after how mutch points generated a new hostile is added
    }
}