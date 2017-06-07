using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dranen
{
    // describes a block on the map with special properties
    public abstract class Event
    {
        private int x;
        private int y;

        public Event(int x , int y)
        {
            this.X = x;
            this.Y = y;
        }
        public int Y
        {
            get { return this.y; }
            set
            {
                if (value >= 2 && value <= Game.HeightConst)
                {
                    y = value;
                }
                else
                {
                    throw new ArgumentException($"X position should be in range [1-{Game.HeightConst - 1}]");
                }
            }
        }

        public int X
        {
            get { return this.x; }
            set
            {
                if (value >= 2 && value <= Game.WidthConst)
                {
                    x = value;
                }
                else
                {
                    throw new ArgumentException($"X position should be in range [2-{Game.WidthConst - 2}]");
                }
            }
        }

    }
}
