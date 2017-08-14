using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Startup.Enums;
using Startup;
using Startup.Commands;

namespace Dranen
{
    public class Navigation
    {
        private static int currentScore = 0;
                
        public static void HostilesProcessor(Protagonist obj, List<EventPoint> events, List<Hostile> hostiles, Game game)
        {
            foreach (var hostile in hostiles)
            {
                if (obj.X < hostile.X)
                {
                    ChaseLeft(hostile, obj);
                }
                if (obj.X > hostile.X)
                {
                    ChaseRight(hostile, obj);
                }
                if (obj.Y < hostile.Y)
                {
                    ChaseUp(hostile, obj);
                }
                if (obj.Y > hostile.Y)
                {
                    ChaseDown(hostile, obj);
                }
                if (obj.Y == hostile.Y && obj.X == hostile.X)
                {
                    if (game.Lives > 0)
                    {
                        game.DecreaseLive();

                        game.AddScore(Settings.Game.LoseLifePenalty);
                        currentScore -= Settings.Game.LoseLifePenalty;
                        ResetHostile.Execute(hostile);
                    }
                    else
                    {
                        game.End();
                    }
                }

                Drawing.Events(events);
                Drawing.DrawHostile(hostile);
                Drawing.ScoreBoard(game);

                ProcessEvents(events, obj, hostile, game);
            }

            if (currentScore >= Settings.Game.HostileAddingScore)
            {
                currentScore = 0;
                GenerateHostile.Execute(hostiles);
            }
        }

        private static void ProcessEvents(List<EventPoint> events, Protagonist obj, Hostile hostile, Game game)
        {
            for (int i = 0; i < events.Count; i++)
            {
                if (events[i].Y == obj.Y && events[i].X == obj.X)
                {                    
                    game.AddScore(events[i].Points);
                    currentScore += events[i].Points;
                    events[i].Points = 0;
                    Sound.Event();
                }

                if (events[i].Points <= Settings.Game.PointDeathThreshold)
                {
                    events.RemoveAt(i);
                }
                else
                {
                    events[i].Deduct();
                }
            }
        }


        public static void Move(Direction direction, Protagonist protagonist, Game game)
        {
            if (direction == Direction.Up)
            {
                MoveUp(protagonist);
            }
            if (direction == Direction.Down)
            {
                MoveDown(protagonist);
            }
            if (direction == Direction.Left)
            {
                MoveLeft(protagonist);
            }
            if (direction == Direction.Right)
            {
                MoveRight(protagonist);
            }
            game.UnPause();
        }

        public static void MoveLeft(Protagonist obj)
        {
            obj.Move(-1, 0);
            Drawing.ClearBackground(obj);
        }

        private static void MoveDown(Protagonist obj)
        {
            obj.Move(0, 1);
            Drawing.ClearBackground(obj);
        }

        private static void MoveRight(Protagonist obj)
        {
            obj.Move(1, 0);
            Drawing.ClearBackground(obj);
        }

        private static void MoveUp(Protagonist obj)
        {
            obj.Move(0, -1);
            Drawing.ClearBackground(obj);
        }

        private static void ChaseLeft(Hostile hostile, Protagonist obj)
        {
            hostile.Move(-1, 0);
            Drawing.Draw(hostile, obj);
        }

        private static void ChaseRight(Hostile hostile, Protagonist obj)
        {
            hostile.Move(1, 0);
            Drawing.Draw(hostile, obj);
        }

        private static void ChaseDown(Hostile hostile, Protagonist obj)
        {
            hostile.Move(0, 1);
            Drawing.Draw(hostile, obj);
        }

        private static void ChaseUp(Hostile hostile, Protagonist obj)
        {
            hostile.Move(0, -1);
            Drawing.Draw(hostile, obj);
        }
    }
}