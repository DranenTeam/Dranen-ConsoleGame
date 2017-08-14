using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Dranen;
using Startup.Interfaces;

namespace Dranen
{
    public class Protagonist : IMovable, ILivable, IPosition
    {
        private int gameWidth;
        private int gameHeight;
        private int x;
        private int y;

        public Protagonist()
        {
            this.GameWidth = Settings.Environment.WidthConst;
            this.GameHeight = Settings.Environment.HeightConst;
            this.X = 0;
            this.Y = 0;
            this.IsAlive = true;
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

        public int X
        {
            get
            {
                return this.x;
            }
            private set
            {
                this.x = value;
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }
            private set
            {
                this.y = value;
            }
        }

        public bool IsAlive { get; private set; }

        public void Move(int x, int y)
        {
            if (this.x + x * 2 < this.gameWidth - 2 && this.x + x * 2 >= 1)
            {
                this.x += x * 2;
            }

            if (this.y + y < this.gameHeight - 1 && this.y + y >= 1)
            {
                this.y += y;
            }
        }
    }
}