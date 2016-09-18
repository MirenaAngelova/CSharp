using System.Linq;
using MassEffect.Exceptions;
using MassEffect.GameObjects.Locations;
using MassEffect.Interfaces;

namespace MassEffect.Engine.Commands
{
    public class PlotJumpCommand : Command
    {
        public PlotJumpCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string shipName = commandArgs[1];
            string destinationName = commandArgs[2];
            IStarship ship = null;
            ship = GameEngine.Starships.FirstOrDefault(s => s.Name == shipName);
            this.ValidateAlive(ship);

            var prevLocation = ship.Location;
            StarSystem location = null;
            location = GameEngine.Galaxy.StarSystems.FirstOrDefault(s => s.Name == destinationName);

            if (prevLocation.Name == destinationName)
            {
                throw new ShipException(string.Format(Messages.ShipAlreadyInStarSystem, destinationName));
            }

            GameEngine.Galaxy.TravelTo(ship, location);
            System.Console.WriteLine(Messages.ShipTraveled, shipName, prevLocation.Name, destinationName);
        }
    }
}
