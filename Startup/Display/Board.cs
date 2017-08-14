using System;
using System.Collections.Generic;
using Startup.Interfaces;
using Startup.Models;

namespace Startup.Display
{
    public class Board
    {
        // Draws an agent( protagonist or hostile) on the console
        public static void Agent(IDynamic agent, ConsoleColor color)
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

        // Draws all agents ( protagonist or hostile) on the console

        public static void AllAgents(IDynamic hostile, IDynamic obj)
        {
            Agent(obj, Settings.Color.Protagonist);
            Agent(hostile, Settings.Color.Hostile);
        }

        // Clears the background and draws the objects
        public static void ClearBackground(IDynamic obj)
        {
            Console.BackgroundColor = Settings.Color.Background;
            Console.Clear();
            Agent(obj, Settings.Color.Protagonist);
        }

        // Draws the clears the background
        public static void ClearBackground()
        {
            Console.BackgroundColor = Settings.Color.Background;
            Console.Clear();
        }

        // Draws all the events
        public static void Events(IList<Event> events)
        {
            foreach (var ev in events)
            {
                Console.BackgroundColor = ev.Color;
                Console.SetCursorPosition(ev.X, ev.Y);
                Console.Write($"{ev.Symbol.PadLeft(2)}");
            }
        }
    }
}