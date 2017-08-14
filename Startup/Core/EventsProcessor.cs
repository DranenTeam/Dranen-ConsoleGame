using Dranen;
using Startup.Commands;
using System.Collections.Generic;

namespace Startup.Core
{
    public class EventsProcessor
    {
        public static void Run(List<EventPoint> events)
        {
            if (events.Count <= Settings.Game.EventsCount)
            {
                GenerateEvent.Execute(events);
            }
        }
    }
}
