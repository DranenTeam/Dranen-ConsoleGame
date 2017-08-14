using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Startup.Interfaces;

namespace Dranen
{
    // describes a block on the map with special properties
    public abstract class Event : IPosition
    {
        private int x;
        private int y;
        private int gameWidth;
        private int gameHeight;

        public Event(int x, int y, int gameWidth, int gameHeight)
        {
            this.GameWidth = gameWidth;
            this.GameHeight = gameHeight;
            this.X = x;
            this.Y = y;
        }

        public int GameHeight
        {
            get { return this.gameHeight; }
            private set
            {
                if (value <= 2)
                {
                    throw new ApplicationException("Invalid game size, game window height must be higher than 2");
                }
                this.gameHeight = value;
            }
        }

        public int GameWidth
        {
            get { return this.gameWidth; }
            private set
            {
                if (value <= 2)
                {
                    throw new ApplicationException("Invalid game size, game window width must be higher than 2");
                }
                this.gameWidth = value;
            }
        }

        public int Y
        {
            get { return this.y; }
            private set
            {
                if (value < 1 && value > this.gameHeight - 1)
                {
                    throw new ArgumentException($"Y position should be in range [1-{this.gameHeight - 1}]");
                }
                this.y = value;
            }
        }

        public int X
        {
            get { return this.x; }
            private set
            {
                if (value < 2 && value > this.gameWidth - 2)
                {
                    throw new ArgumentException($"X position should be in range [2-{this.gameWidth - 2}]");
                }

                this.x = value;
            }
        }
    }
}