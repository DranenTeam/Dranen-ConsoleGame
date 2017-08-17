using Startup.Core.Arguments;
using Startup.Interfaces;
using Startup.Models;
using System;
using System.Collections.Generic;

namespace Startup.Core
{
    public class HostilesProcessor : IProcessor
    {
        private IList<IHostile> hostiles;
        private Game game;
        private int lastScore;
        private int counter;

        public event EventHandler<OverlapArgs> OverlapHandler;

        public void Overlap()
        {
            this.OverlapHandler?.Invoke(this, new OverlapArgs(this.counter));
        }

        public HostilesProcessor(IList<IHostile> hostiles, Game game)
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
                this.CreateNewHostile(this.hostiles);
            }
        }

        private void CreateNewHostile(IList<IHostile> hostiles)
        {
            var rnd = new Random();
            var x = rnd.Next(2, (Settings.Environment.Width / 2) - 2) * 2;
            var y = rnd.Next(2, Settings.Environment.Height - 2);
            var hostile = new Hostile(x, y);

            this.OverlapHandler += hostile.OnOverlap;

            hostiles.Add(hostile);
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
                var overlapCount = 0;
                foreach (var h in this.hostiles)
                {
                    if (hostile.Y == h.Y && hostile.X == h.X)
                    {
                        overlapCount++;
                    }
                }

                if (overlapCount > 1)
                {
                    ++this.counter;
                    Overlap();
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