using Dranen;
using System;

namespace Startup
{
    public class Hostile
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public int Slowliness { get; private set; }
        private int dx;
        private int dy;

        public Hostile(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.IsAlive = true; // Some Buffs can kill it
            var rdm = new Random();
            this.Slowliness = rdm.Next(5, 15);
            this.dx = Slowliness;
            this.dy = Slowliness;
        }

        public bool IsAlive { get; private set; }

        public void Chase(int x, int y)
        {
            if (this.X + x * 2 < Game.WidthConst - 2 && this.X + x * 2 >= 1)
            {
                dx -= 1;
                if (dx == 0)
                {
                    dx = Slowliness;
                    this.X += x * 2;
                }
            }

            if (this.Y + y < Game.HeightConst - 1 && this.Y + y >= 1)
            {
                dy -= 1;
                if (dy == 0)
                {
                    dy = Slowliness;
                    this.Y += y;
                }
            }
        }

        public void RandomReset()
        {
            var rnd = new Random();
            var x = rnd.Next(2, (Game.WidthConst / 2) - 2) * 2;
            var y = rnd.Next(2, Game.HeightConst - 2);
            this.X = x;
            this.Y = y;
        }
    }
}
