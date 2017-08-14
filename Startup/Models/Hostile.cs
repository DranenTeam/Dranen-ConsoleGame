using System;
using Startup.Exceptions;
using Startup.Interfaces;

namespace Startup.Models
{
    public class Hostile : IDynamic
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
            this.dx = this.Slowliness;
            this.dy = this.Slowliness;
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
                this.dx -= 1;
                if (this.dx == 0)
                {
                    this.dx = this.Slowliness;
                    this.X += x * 2;
                }
            }

            if (this.Y + y < Settings.Environment.Height - 1 && this.Y + y >= 1)
            {
                this.dy -= 1;
                if (this.dy == 0)
                {
                    this.dy = this.Slowliness;
                    this.Y += y;
                }
            }
        }
    }
}