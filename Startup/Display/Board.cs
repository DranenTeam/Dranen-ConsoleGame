using Startup.Interfaces;
using Startup.Models;
using System;
using System.Collections.Generic;

namespace Startup.Display
{
    public class Board
    {
        // Draws an agent( protagonist or hostile) on the console
        public void Agent(IDynamic agent, ConsoleColor color)
        {
            Console.BackgroundColor = color;
            Console.SetCursorPosition(agent.X, agent.Y);
            if (agent.Y == 0 || agent.X == 0)
            {
                Console.Write("..");
            }
            else
            {
                Console.Write("  ");
            }
        }

        // Clears the background and draws the objects
        public void ClearBackground(IDynamic obj)
        {
            Console.BackgroundColor = Settings.Color.Background;
            Console.Clear();
            Agent(obj, Settings.Color.Protagonist);
        }

        // Draws the clears the background
        public void ClearBackground()
        {
            Console.BackgroundColor = Settings.Color.Background;
            Console.Clear();
        }

        // Draws all the events
        public void Events(IList<GameEvent> events)
        {
            foreach (var ev in events)
            {
                Console.BackgroundColor = ev.Color;
                Console.SetCursorPosition(ev.X, ev.Y);
                Console.Write($"{ev.Symbol.PadLeft(2)}");
            }
        }

        // Draws all the events
        public void Hostiles(IList<IHostile> hostiles)
        {
            foreach (var hostile in hostiles)
            {
                Console.BackgroundColor = Settings.Color.Hostile;
                Console.SetCursorPosition(hostile.X, hostile.Y);
                Console.Write("  ");
            }
        }

        public void All(IList<IHostile> hostiles, Protagonist protagonist,
            IList<GameEvent> events)
        {
            Hostiles(hostiles);
            Agent(protagonist, Settings.Color.Protagonist);
            Events(events);
        }
    }
}