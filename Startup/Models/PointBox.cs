using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Startup.Exceptions;

namespace Dranen
{
    // describes a block on the map with special properties
    public class PointBox : Event
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
                    throw new InvalidPointDeductorValueException("PointDeductor must be positive");
                }
                this.pointDeductor = value;
            }
        }

        public PointBox(int x, int y, int points, int deduction = 1)
            : base(x, y)
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