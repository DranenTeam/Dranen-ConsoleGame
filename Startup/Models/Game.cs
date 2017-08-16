using Startup.Exceptions;

namespace Startup
{
    public class Game
    {
        private bool isPaused;
        private bool isEnd;
        private int lives;
        private int score;
        private string playersName;

        public Game(int lives)
        {
            this.isPaused = false;
            this.isEnd = false;
            this.lives = lives;
            this.score = 0;
            this.playersName = "Player";
        }

        public int Score
        {
            get { return this.score; }
            private set { this.score = value; }
        }

        public bool IsPaused
        {
            get { return this.isPaused; }
            private set { this.isPaused = value; }
        }

        public bool IsEnd
        {
            get { return this.isEnd; }
            private set { this.isEnd = value; }
        }

        public int Lives
        {
            get { return this.lives; }
            private set
            {
                if (value < 1)
                {
                    throw new InvalidLivesCountException();
                }

                this.lives = value;
            }
        }

        public string PlayersName
        {
            get { return this.playersName; }
            set { this.playersName = value; }
        }

        public void AddScore(int score)
        {
            this.score += score;
        }

        public void Pause()
        {
            this.isPaused = true;
        }

        public void UnPause()
        {
            this.isPaused = false;
        }

        public void End()
        {
            this.IsEnd = true;
        }

        public void DecreaseLive()
        {
            this.lives--;
            Sound.LostLife();
        }
    }
}