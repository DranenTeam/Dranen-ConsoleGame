using System.Collections.Generic;
using Startup.Core.Commands;
using Startup.Models;

namespace Startup.Core
{
    public class EventsProcessor
    {
        public static void Run(List<Event> events)
        {
            if (events.Count <= Settings.Game.EventsCount)
            {
                GenerateEvent.Execute(events);
            }
        }
    }
}