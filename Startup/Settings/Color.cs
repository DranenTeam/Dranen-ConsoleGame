using System;

namespace Startup.Settings
{
    internal class Color
    {
        // just do not allow background protagonist and events to be the same color

        public static readonly ConsoleColor Background = ConsoleColor.DarkGray;
        public static readonly ConsoleColor EndScreenBackground = ConsoleColor.Black;
        public static readonly ConsoleColor Protagonist = ConsoleColor.Black;
        public static readonly ConsoleColor PointEventBest = ConsoleColor.DarkGreen;
        public static readonly ConsoleColor PointEventGood = ConsoleColor.DarkYellow;
        public static readonly ConsoleColor PointEventBad = ConsoleColor.DarkRed;
        public static readonly ConsoleColor Hostile = ConsoleColor.Red;
    }
}