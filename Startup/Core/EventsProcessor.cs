using System;
using System.Collections.Generic;
using Startup.Core.Commands;
using Startup.Models;

namespace Startup.Core
{
    public class EventsProcessor
    {
        private IList<Event> events;

        public EventsProcessor(List<Event> events)
        {
            this.events = events;
        }

        public void Run(Random rnd)
        {
            var x = rnd.Next(1, (Settings.Environment.Width / 2) - 3);
            var y = rnd.Next(1, (Settings.Environment.Height / 2) - 2);
            var time = rnd.Next(15, 95);
            PointBox ev = new PointBox(x * 2, y * 2, time);

            events.Add(ev);
        }
    }
}