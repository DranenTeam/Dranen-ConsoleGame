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
            Console.BackgroundColor = Game.ProtagonistColor;
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
            Console.BackgroundColor = Game.HostileColor;
            Console.SetCursorPosition(hostile.X, hostile.Y);
            Console.Write("[]");
        }

        public static void ClearBackground(Protagonist obj)
        {
            Console.BackgroundColor = Game.BackgroundColor;
            Console.Clear();
            DrawProtagonist(obj);
            DrawPlayground(obj);
        }

        public static void ClearBackground(Hostile hostile, Protagonist obj)
        {
            Console.BackgroundColor = Game.BackgroundColor;
            Console.Clear();
            DrawProtagonist(obj);
            DrawHostile(hostile);
            DrawPlayground(obj);
        }

        public static void Events(List<EventPoint> events)
        {


            foreach (var ev in events)
            {

                if (ev.Points >= 2000)
                {
                    Console.BackgroundColor = Game.PointEventColorBest;
                }
                else if (ev.Points >= 1000)
                {
                    Console.BackgroundColor = Game.PointEventColorGood;
                }
                else
                {
                    Console.BackgroundColor = Game.PointEventColorBad;

                }
                Console.SetCursorPosition(ev.X, ev.Y);
                Console.Write($"{ev.Points.ToString().PadLeft(4)}");
            }

        }
    }
}
