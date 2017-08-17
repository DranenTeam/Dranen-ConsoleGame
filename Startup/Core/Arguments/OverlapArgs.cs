using System;

namespace Startup.Core.Arguments
{
    public class OverlapArgs : EventArgs
    {
        private int counter;

        public OverlapArgs(int counter)
        {
            this.Counter = counter;
        }

        public int Counter
        {
            get { return this.counter; }
            set { this.counter = value; }
        }
    }
}