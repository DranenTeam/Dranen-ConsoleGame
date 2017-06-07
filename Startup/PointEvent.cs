﻿using System;
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
                if (value >= 0)
                {
                    pointDeductor = value;
                }
                else
                {
                       throw new ArgumentException("PointDeductor must be positive");
                }
            }
        }

        public EventPoint(int x, int y, int points, int deduction = 5) : base(x, y)
        {
            this.Points = points;
            this.PointDeductor = deduction;
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
                this.points -=pointDeductor;
            }
        }

    }
}
