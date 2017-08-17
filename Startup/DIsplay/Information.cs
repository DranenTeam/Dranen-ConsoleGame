using System;

namespace Startup.Display
{
    public class Information
    {
        // Draws the score board on the console title
        public void ScoreBoard(Game game)
        {
            Console.Title = game.Score.ToString();
        }

        // Draws  remaning lives board on the console
        public void LivesBoard(Game game)
        {
            Console.SetCursorPosition(15, 0);
            Console.WriteLine($"Lives: {game.Lives}");
        }
    }
}