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

        public static void ScoreBoard()
        {
            Console.Title = Game.Score.ToString();
            //Console.SetCursorPosition(Game.WidthConst/2, 0);
            //Console.Background = Game.ScoreBoardColor;
            //Console.Write($"{Game.Score.ToString().PadLeft(6)}");
        }

        public static void LivesBoard()
        {
            Console.SetCursorPosition(15, 0);
            Console.WriteLine($"Lives: {Game.Lives}");
        }

        public static void DrawPlayground(Protagonist obj)
        {
            //for (int i = 0; i < Game.WidthConst; i += 20)
            //{
            //    Console.SetCursorPosition(i, 0);
            //    Console.Write("  ");
            //    Console.SetCursorPosition(i, Game.HeightConst - 1);
            //    Console.Write("  ");
            //}

            //for (int i = 0; i < Game.HeightConst; i += 10)
            //{
            //    Console.SetCursorPosition(0, i);
            //    Console.Write("  ");
            //    Console.SetCursorPosition(Game.WidthConst - 2, i);
            //    Console.Write("  ");
            //}
            //Console.SetCursorPosition(obj.X, obj.Y);
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
            DrawPlayground(obj);
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
            DrawPlayground(obj);
        }

        public static void Events(List<EventPoint> events)
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