using System;

namespace Startup.Settings
{
    internal class Color
    {
        // just do not allow background protagonist and events to be the same color

        public static ConsoleColor Background = ConsoleColor.DarkGray;
        public static ConsoleColor Protagonist = ConsoleColor.Black;
        public static ConsoleColor PointEventBest = ConsoleColor.DarkGreen;
        public static ConsoleColor PointEventGood = ConsoleColor.DarkYellow;
        public static ConsoleColor PointEventBad = ConsoleColor.DarkRed;
        public static ConsoleColor Hostile = ConsoleColor.Red;
    }
}