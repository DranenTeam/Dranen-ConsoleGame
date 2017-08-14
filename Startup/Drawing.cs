using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dranen;
using Startup;

namespace Dranen
{
    public class Drawing
    {
        public static void DrawProtagonist(Protagonist obj)
        {
            Console.BackgroundColor = Settings.Color.Protagonist;
            Console.SetCursorPosition(obj.X, obj.Y);
            if (obj.Y == 0 || obj.X == 0)
            {
                Console.Write("..");
            }
            else
            {
                Console.Write("  ");
            }
        }

        public static void ScoreBoard(Game game)
        {
            Console.Title = game.Score.ToString();
            //Console.SetCursorPosition(Game.Width/2, 0);
            //Console.Background = Game.ScoreBoardColor;
            //Console.Write($"{Game.Score.ToString().PadLeft(6)}");
        }

        public static void LivesBoard(Game game)
        {
            Console.SetCursorPosition(15, 0);
            Console.WriteLine($"Lives: {game.Lives}");
        }

        public static void DrawHostile(Hostile hostile)
        {
            Console.BackgroundColor = Settings.Color.Hostile;
            Console.SetCursorPosition(hostile.X, hostile.Y);
            Console.Write("  ");
        }

        public static void ClearBackground(Protagonist obj)
        {
            Console.BackgroundColor = Settings.Color.Background;
            Console.Clear();
            DrawProtagonist(obj);
        }

        public static void ClearBackground()
        {
            Console.BackgroundColor = Settings.Color.Background;
            Console.Clear();
        }

        public static void Draw(Hostile hostile, Protagonist obj)
        {
            DrawProtagonist(obj);
            DrawHostile(hostile);
        }

        public static void Events(IList<PointBox> events)
        {
            foreach (var ev in events)
            {
                if (ev.Points >= Settings.Game.PointEventBestScore)
                {
                    Console.BackgroundColor = Settings.Color.PointEventBest;
                }
                else if (ev.Points >= Settings.Game.PointEventGoodScore)
                {
                    Console.BackgroundColor = Settings.Color.PointEventGood;
                }
                else
                {
                    Console.BackgroundColor = Settings.Color.PointEventBad;
                }
                Console.SetCursorPosition(ev.X, ev.Y);
                Console.Write($"{ev.Points.ToString().PadLeft(2)}");
            }
        }
    }
}