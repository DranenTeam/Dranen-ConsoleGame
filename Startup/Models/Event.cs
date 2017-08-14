using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Startup.Exceptions;
using Startup.Interfaces;

namespace Dranen
{
    // describes a block on the map with special properties
    public abstract class Event : IEvent, IColor, ISymbol
    {
        private int x;
        private int y;
        private int gameWidth;
        private int gameHeight;

        public Event(int x, int y)
        {
            this.GameWidth = Settings.Environment.Width;
            this.GameHeight = Settings.Environment.Height;
            this.X = x;
            this.Y = y;
        }

        public virtual ConsoleColor Color
        {
            get;
        }

        public int X
        {
            get { return this.x; }
            private set
            {
                if (value < 2 && value > this.gameWidth - 2)
                {
                    throw new InvalidCoordinatesException($"X position should be in range [2-{this.gameWidth - 2}]");
                }

                this.x = value;
            }
        }

        public int Y
        {
            get { return this.y; }
            private set
            {
                if (value < 1 && value > this.gameHeight - 1)
                {
                    throw new InvalidCoordinatesException($"Y position should be in range [1-{this.gameHeight - 1}]");
                }
                this.y = value;
            }
        }

        public int GameHeight
        {
            get { return this.gameHeight; }
            private set
            {
                if (value <= 2)
                {
                    throw new InvalidGameHeightException();
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
                    throw new InvalidGameWIdthException();
                }
                this.gameWidth = value;
            }
        }

        public virtual string Symbol { get; }
        public virtual bool IsActive { get; }

        public abstract void TimeTrigger();

        public abstract int Activate();
    }
}