using Dranen;
using Startup.Interfaces;
using System;

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
            this.GameWidth = Settings.Environment.WidthConst;
            this.GameHeight = Settings.Environment.HeightConst;
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
                    throw new ApplicationException("Invalid game size, game window width must be higher than 2");
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
                    throw new ApplicationException("Invalid game size, game window height must be higher than 2");
                }
                this.gameHeight = value;
            }
        }

        public void RandomReset()
        {
            var rnd = new Random();
            var x = rnd.Next(2, (Settings.Environment.WidthConst / 2) - 2) * 2;
            var y = rnd.Next(2, Settings.Environment.HeightConst - 2);
            this.X = x;
            this.Y = y;
        }

        public void Move(int x, int y)
        {
            if (this.X + x * 2 < Settings.Environment.WidthConst - 2 && this.X + x * 2 >= 1)
            {
                dx -= 1;
                if (dx == 0)
                {
                    dx = Slowliness;
                    this.X += x * 2;
                }
            }

            if (this.Y + y < Settings.Environment.HeightConst - 1 && this.Y + y >= 1)
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