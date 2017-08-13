using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dranen
{
    // describes a block on the map with special properties
    public class EventPoint : Event
    {
        private int points;
        private int pointDeductor;

        public int PointDeductor
        {
            get { return this.pointDeductor; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("PointDeductor must be positive");
                }
                this.pointDeductor = value;
            }
        }

        public EventPoint(int x, int y, int points, int gameWidth, int gameHeight, int deduction = 1) : base(x, y, gameWidth, gameHeight)
        {
            this.Points = points;
            this.PointDeductor = Settings.Game.PointDeductor;
        }

        public int Points
        {
            get { return this.points; }
            set { points = value; }
        }

        public void Deduct()
        {
            if (this.points - this.pointDeductor > 0)
            {
                this.points -= pointDeductor;
            }
        }
    }
}