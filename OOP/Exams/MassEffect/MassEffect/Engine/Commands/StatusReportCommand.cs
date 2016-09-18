namespace MassEffect.Engine.Commands
{
    using System.Linq;
    using MassEffect.Interfaces;

    public class StatusReportCommand : Command
    {
        public StatusReportCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string shipName = commandArgs[1];
            IStarship ship = null;
            ship = GameEngine.Starships.FirstOrDefault(a => a.Name == shipName);

            System.Console.WriteLine(ship.ToString());
        }
    }
}
