using Startup.Constants;
using Startup.Interfaces;
using System;
using System.Media;
using System.Threading;

namespace Startup.Display.SubMenues
{
    public class Credits : ISoundable
    {
        public Credits(string message, int rollSpeed = 250)
        {
            Console.Clear();
            MakeSound(FileSoundPath.CreditsSound);

            var cursor = 1;

            for (int i = 0; i < 15; i++)
            {
                Console.Clear();
                Console.SetCursorPosition(15, cursor);
                Console.WriteLine(message);
                Thread.Sleep(rollSpeed);
                cursor++;
                if (cursor == Console.WindowHeight)
                {
                    cursor = 1;
                }
            }
            Console.ReadKey(); //TODO: Break the while and go back in the menu
        }

        public void MakeSound(string filePath)
        {
            SoundPlayer makeSound = new SoundPlayer(filePath);
            makeSound.Play();
        }
    }
}