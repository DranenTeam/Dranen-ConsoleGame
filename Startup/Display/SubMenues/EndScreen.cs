﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Startup.Constants;
using Startup.Interfaces;

namespace Startup.Display.SubMenues
{
    public class EndScreen : ISound
    {
        public EndScreen(Stopwatch stopwatch, Game game)
        {
            Console.Clear();
            Display.Menu.Logo();
            stopwatch.Stop();
            Console.SetCursorPosition(9, 10);
            Console.WriteLine($"Sorry {game.PlayersName}, You died! :(");
            Console.SetCursorPosition(10, 12);
            Console.WriteLine($"Time: {stopwatch.Elapsed.TotalSeconds.ToString("0")}");
            Console.SetCursorPosition(10, 13);
            Console.WriteLine($"Score: {game.Score}");
            Console.SetCursorPosition(9, 15);
            Console.WriteLine($"Prss any key to start over.");
            MakeSound(FileSoundPath.GameOver);

            if (true)
            {
                Thread.Sleep(2000);
                Console.ReadKey();
            }
        }

        public void MakeSound(string filePath)
        {
            SoundPlayer makeSound = new SoundPlayer(filePath);
            makeSound.Play();
        }
    }
}