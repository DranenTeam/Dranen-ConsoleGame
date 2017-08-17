using System;

namespace Startup.Display
{
    public class StaticMessages
    {
        public static string GamePause => "Press UP, DOWN, LEFT or RIGHT to continue.";

        public string AuthorsList
            =>
                $"Drenen 2017{Environment.NewLine}" +
                $"Theo Dor{Environment.NewLine}" +
                $"Nikoleta Valchinova{Environment.NewLine}" +
                $"Vladimir Gadjov{Environment.NewLine}" +
                $"Kostadin Valchev{Environment.NewLine}" +
                $"Dimitar Nikolov"
        ;

        public string EnterNameQuestion => "What is your name?";
        public string GoodLuck => "Good luck in your quest!";

        public string HowToPlayInstructions
            =>
                $"1. Chase the points{Environment.NewLine}" +
                $"2. Dodge the red hostiles{Environment.NewLine}" +
                $"3. Repeat{Environment.NewLine}"
        ;
    }
}