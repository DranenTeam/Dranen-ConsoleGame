using Dranen;

namespace Startup
{
    public class Hostile
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Hostile(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.IsAlive = true; // Some Buffs can kill it
        }

        public bool IsAlive { get; private set; }

        public void Chase(int x, int y)
        {

            if (this.X + x * 2 < Game.WidthConst - 2 && this.X + x * 2 >= 1)
            {
                this.X += x * 2;
            }

            if (this.Y + y < Game.HeightConst - 1 && this.Y + y >= 1)
            {
                this.Y += y;
            }
        }
    }
}
