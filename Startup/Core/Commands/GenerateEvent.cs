using Dranen;
using System;
using System.Collections.Generic;

namespace Startup.Commands
{
    public class GenerateEvent
    {
        public static void Execute(List<PointBox> events)
        {
            var rnd = new Random();
            var x = rnd.Next(1, (Settings.Environment.Width / 2) - 3);
            var y = rnd.Next(1, (Settings.Environment.Height / 2) - 2);
            var time = rnd.Next(15, 95);
            PointBox ev = new PointBox(x * 2, y * 2, time);

            events.Add(ev);
        }
    }
}