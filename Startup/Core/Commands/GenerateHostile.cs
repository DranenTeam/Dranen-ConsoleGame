using System;
using System.Collections.Generic;
using Startup.Models;

namespace Startup.Core.Commands
{
    public class GenerateHostile
    {
        public static void Execute(List<Hostile> hostiles)
        {
            var rnd = new Random();
            var x = rnd.Next(2, (Settings.Environment.Width / 2) - 2) * 2;
            var y = rnd.Next(2, Settings.Environment.Height - 2);
            hostiles.Add(new Hostile(x, y));
        }
    }
}