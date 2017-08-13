using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Startup;

namespace Dranen
{
    public static class Game
    {
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
            set
            {
                if (value < 3)
                {
                    Sound.LostLife();
                    lives = value;
                }
                else
                {
                    lives = value;
                }

                lives = value;
            }
        }

        public static StringBuilder PlayersName
        {
            get { return playersName; }
            set { playersName = value; }
        }
    }
}