using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Startup.Models;

namespace Startup.Core
{
    public class HostilesProcessor
    {
        private IList<Hostile> hostiles;
        private Game game;
        private int lastScore;

        public HostilesProcessor(IList<Hostile> hostiles, Game game)
        {
            this.hostiles = hostiles;
            this.game = game;
            this.lastScore = 0;
        }

        public void Run()
        {
            if (this.game.Score - lastScore >= Settings.Game.HostileAddingScore)
            {
                this.lastScore += this.game.Score;
                Execute(this.hostiles);
            }
        }

        private void Execute(IList<Hostile> hostiles)
        {
            var rnd = new Random();
            var x = rnd.Next(2, (Settings.Environment.Width / 2) - 2) * 2;
            var y = rnd.Next(2, Settings.Environment.Height - 2);
            hostiles.Add(new Hostile(x, y));
        }

        public void ProcessHostilesAndGetScores(Protagonist protagonist, Game game)
        {
            int points = 0;
            foreach (var hostile in this.hostiles)
            {
                if (protagonist.X < hostile.X)
                {
                    hostile.Move(-1, 0);
                }
                if (protagonist.X > hostile.X)
                {
                    hostile.Move(1, 0);
                }
                if (protagonist.Y < hostile.Y)
                {
                    hostile.Move(0, -1);
                }
                if (protagonist.Y > hostile.Y)
                {
                    hostile.Move(0, 1);
                }

                if (protagonist.Y == hostile.Y && protagonist.X == hostile.X)
                {
                    if (game.Lives > 0)
                    {
                        game.DecreaseLive();

                        game.AddScore(Settings.Game.LoseLifePenalty);
                        points -= Settings.Game.LoseLifePenalty;
                        hostile.RandomReset();
                    }
                    else
                    {
                        game.End();
                    }
                }
            }
        }
    }
}