using System;
using System.Collections.Generic;
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
            while (this.events.Count < Settings.Game.EventsCount)
            {
                var x = rnd.Next(1, (Settings.Environment.Width / 2) - 1);
                var y = rnd.Next(1, (Settings.Environment.Height / 2));
                var time = rnd.Next(15, 95);
                PointBox ev = new PointBox(x * 2, y * 2, time);

                this.events.Add(ev);
            }
        }

        public int ProcessEventsAndGetScores(Protagonist protagonist, Game game)
        {
            int points = 0;
            for (int i = 0; i < events.Count; i++)
            {
                var currentEvent = this.events[i];
                if (currentEvent.Y == protagonist.Y && currentEvent.X == protagonist.X)
                {
                    points += currentEvent.Activate();
                    game.AddScore(points);
                    Sound.Event();
                }
                currentEvent.TimeTrigger();
                if (!currentEvent.IsActive)
                {
                    this.events.RemoveAt(i);
                }
            }

            return points;
        }
    }
}