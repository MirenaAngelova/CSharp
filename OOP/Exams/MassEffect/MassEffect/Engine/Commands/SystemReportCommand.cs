using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassEffect.Interfaces;

namespace MassEffect.Engine.Commands
{
    class SystemReportCommand : Command
    {
        public SystemReportCommand(IGameEngine gameEngine) : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string locationName = commandArgs[1];
            var starships = this.GameEngine.Starships
                .Where(s => s.Location.Name == locationName);

            var intactShips = starships
                .Where(s => s.Health > 0)
                .OrderByDescending(s => s.Health)
                .ThenByDescending(s => s.Shields);

            StringBuilder exit = new StringBuilder();
            exit.AppendLine("Intact ships:");
            exit.Append(intactShips.Any() ? string.Join("\n", intactShips) : "N/A");

            var destroyed = this.GameEngine.Starships
                .Where(s => s.Location.Name == locationName);

            var destroyedShips = destroyed
                .Where(d => d.Health <= 0)
                .OrderBy(d => d.Name);

            exit.AppendLine("Destroyed ships:");
            exit.Append(destroyedShips.Any() ? string.Join("\n", destroyedShips) : "N/A");
            Console.WriteLine(exit.ToString());
        }
    }
}
