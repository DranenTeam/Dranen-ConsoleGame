using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dranen;

namespace Dranen
{
    public class Drawing
    {
        public static void DrawProtagonist(Protagonist obj)
        {
            Console.BackgroundColor = GameParameter.ProtagonistColor;
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
            for (int i = 0; i < GameParameter.WidthConst; i += 20)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("  ");
                Console.SetCursorPosition(i, GameParameter.HeightConst - 1);
                Console.Write("  ");
            }

            for (int i = 0; i < GameParameter.HeightConst; i += 10)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("  ");
                Console.SetCursorPosition(GameParameter.WidthConst - 2, i);
                Console.Write("  ");
            }
            Console.SetCursorPosition(obj.X, obj.Y);
        }
        public static void ClearBackground(Protagonist obj)
        {
            Console.BackgroundColor = GameParameter.BackgroundColor;
            Console.Clear();
            DrawProtagonist(obj);
            DrawPlayground(obj);
        }

    }
}
