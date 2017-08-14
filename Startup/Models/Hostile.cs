using Dranen;
using Startup.Interfaces;
using System;
using Startup.Exceptions;

namespace Startup
{
    public class Hostile : IPosition, IMovable
    {
        private int dx;
        private int dy;
        private int x;
        private int y;
        private int gameHeight;
        private int gameWidth;

        public Hostile(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.GameWidth = Settings.Environment.Width;
            this.GameHeight = Settings.Environment.Height;
            var rdm = new Random();
            this.Slowliness = rdm.Next(5, 12);
            this.dx = Slowliness;
            this.dy = Slowliness;
            Sound.Hostile();
        }

        public int X
        {
            get { return this.x; }
            private set { this.x = value; }
        }

        public int Y
        {
            get { return this.y; }
            private set { this.y = value; }
        }

        public int Slowliness { get; private set; }

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

        public void RandomReset()
        {
            var rnd = new Random();
            var x = rnd.Next(2, (Settings.Environment.Width / 2) - 2) * 2;
            var y = rnd.Next(2, Settings.Environment.Height - 2);
            this.X = x;
            this.Y = y;
        }

        public void Move(int x, int y)
        {
            if (this.X + x * 2 < Settings.Environment.Width - 2 && this.X + x * 2 >= 1)
            {
                dx -= 1;
                if (dx == 0)
                {
                    dx = Slowliness;
                    this.X += x * 2;
                }
            }

            if (this.Y + y < Settings.Environment.Height - 1 && this.Y + y >= 1)
            {
                dy -= 1;
                if (dy == 0)
                {
                    dy = Slowliness;
                    this.Y += y;
                }
            }
        }
    }
}