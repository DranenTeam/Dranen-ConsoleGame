using System;
using Startup.Exceptions;

namespace Startup.Models
{
    // describes a block on the map with special properties
    public class PointBox : Event
    {
        private int points;
        private int pointDeductor;
        private bool isActive;

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
            this.points = points;
            this.PointDeductor = Settings.Game.PointDeductor;
            this.isActive = true;
        }

        public override ConsoleColor Color
        {
            get
            {
                if (this.points >= Settings.Game.PointEventBestScore)
                {
                    return Settings.Color.PointEventBest;
                }

                if (this.points >= Settings.Game.PointEventGoodScore)
                {
                    return Console.BackgroundColor = Settings.Color.PointEventGood;
                }

                return Console.BackgroundColor = Settings.Color.PointEventBad;
            }
        }

        public override string Symbol
        {
            get { return this.points.ToString(); }
        }

        public override bool IsActive
        {
            get { return this.isActive; }
        }

        public override void TimeTrigger()
        {
            if (this.points - this.pointDeductor > 0)
            {
                this.points -= this.pointDeductor;
            }
            else
            {
                this.isActive = false;
            }
        }

        public override int Activate()
        {
            this.isActive = false;
            return this.points;
        }
    }
}