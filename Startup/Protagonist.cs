using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dranen;

namespace Dranen
{
    public class Protagonist
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Protagonist()
        {
            this.X = 0;
            this.Y = 0;
            this.IsAlive = true;
        }

        public bool IsAlive { get; private set; }


        public void Move(int x, int y)
        {

            if (this.X + x * 2 < GameParameter.WidthConst - 2 && this.X + x * 2 >= 1)
            {
                this.X += x * 2;
            }

            if (this.Y + y < GameParameter.HeightConst - 1 && this.Y + y >= 1)
            {
                this.Y += y;
            }
        }
    }
}
