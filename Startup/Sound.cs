using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startup
{
    public static class Sound
    {
        public static void GameOver()
        {
            System.Media.SoundPlayer gameOver = new System.Media.SoundPlayer("..//..//Sounds//Game over.wav");
            gameOver.PlaySync();
        }
        public static void MenuEffect()
        {
            System.Media.SoundPlayer menuEffect = new System.Media.SoundPlayer("..//..//Sounds//MenuEffect.wav");
            menuEffect.Play();
        }
        public static void Hostile()
        {
            System.Media.SoundPlayer hostile = new System.Media.SoundPlayer("..//..//Sounds//Hostile.wav");
            hostile.Play();
        }
        public static void Event()
        {
            System.Media.SoundPlayer eventsound = new System.Media.SoundPlayer("..//..//Sounds//Event.wav");
            eventsound.Play();
        }
        public static void GameStartSound()
        {
            System.Media.SoundPlayer creditsSound = new System.Media.SoundPlayer("..//..//Sounds//GameStartSound.wav");
            creditsSound.Play();
        }
        public static void CreditsSound()
        {
            System.Media.SoundPlayer creditsSound = new System.Media.SoundPlayer("..//..//Sounds//GameStartSound.wav");
            creditsSound.Play();
        }
        public static void LostLife()
        {
            System.Media.SoundPlayer gameOver = new System.Media.SoundPlayer("..//..//Sounds//LostLife.wav");
            gameOver.Play();
        }
    }
}
