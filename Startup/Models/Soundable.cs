using Startup.Interfaces;
using System.Media;

namespace Startup
{
    public class Soundable : ISoundable
    {
        public void MakeSound(string filePath)
        {
            SoundPlayer makeSound = new SoundPlayer(filePath);
            makeSound.Play();
        }
    }
}