namespace BoatRacingSimulator.Models.Races
{
    using Interfaces;

    public class StartRace 
    {
        public StartRace(IRace race, IBoat boat)
        {
            this.Race = race;
            this.Boat = boat;
        }

        public IBoat Boat { get; set; }

        public IRace Race { get; private set; }
    }
}