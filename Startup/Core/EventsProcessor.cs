using Startup.Constants;
using Startup.Interfaces;
using Startup.Models;
using System;
using System.Collections.Generic;
using System.Media;

namespace Startup.Core
{
    public class EventsProcessor : IProcessor, ISoundable
    {
        private IList<GameEvent> events;
        private Random randomGenerator;

        public EventsProcessor(List<GameEvent> events, Random randomGenerator)
        {
            this.events = events;
            this.randomGenerator = randomGenerator;
        }

        public void Run()
        {
            while (this.events.Count < Settings.Game.EventsCount)
            {
                var x = this.randomGenerator.Next(1, (Settings.Environment.Width / 2) - 1);
                var y = this.randomGenerator.Next(1, (Settings.Environment.Height / 2));
                var time = this.randomGenerator.Next(15, 95);
                PointBoxGameEvent ev = new PointBoxGameEvent(x * 2, y * 2, time);

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
                    this.MakeSound(FileSoundPath.Event);
                }
                currentEvent.TimeTrigger();
                if (!currentEvent.IsActive)
                {
                    this.events.RemoveAt(i);
                }
            }

            return points;
        }

        public void MakeSound(string filePath)
        {
            SoundPlayer makeSound = new SoundPlayer(filePath);
            makeSound.Play();
        }
    }
}