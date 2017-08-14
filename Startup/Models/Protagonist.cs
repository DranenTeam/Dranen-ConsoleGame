using Startup.Exceptions;
using Startup.Interfaces;

namespace Startup.Models
{
    public class Protagonist : IDynamic, ILivable
    {
        private int gameWidth;
        private int gameHeight;
        private int x;
        private int y;

        public Protagonist()
        {
            this.GameWidth = Settings.Environment.Width;
            this.GameHeight = Settings.Environment.Height;
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