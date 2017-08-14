using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dranen;
using Startup;
using Startup.Interfaces;

namespace Dranen
{
    public class Draw
    {
        // Draws the score board on the console title
        public static void ScoreBoard(Game game)
        {
            Console.Title = game.Score.ToString();
        }

        // Draws the remaning lives board on the console
        public static void LivesBoard(Game game)
        {
            Console.SetCursorPosition(15, 0);
            Console.WriteLine($"Lives: {game.Lives}");
        }

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

        public static void All(IDynamic hostile, IDynamic obj)
        {
            Agent(obj, Settings.Color.Protagonist);
            Agent(hostile, Settings.Color.Hostile);
        }

        // Draws the clears the background and draws the objects
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