using System;

namespace Startup.Display
{
    public class Information
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
            Console.WriteLine($"Lifes: {game.Lives}");
        }
    }
}