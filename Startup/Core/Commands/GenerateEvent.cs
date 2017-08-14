using Dranen;
using System;
using System.Collections.Generic;

namespace Startup.Commands
{
    public class GenerateEvent
    {
        public static void Execute(List<EventPoint> events)
        {
            var rnd = new Random();
            var x = rnd.Next(1, (Settings.Environment.WidthConst / 2) - 3);
            var y = rnd.Next(1, (Settings.Environment.HeightConst / 2) - 2);
            var time = rnd.Next(15, 95);
            EventPoint ev = new EventPoint(x * 2, y * 2, Settings.Environment.WidthConst, Settings.Environment.HeightConst, time);

            events.Add(ev);
        }
    }
}
