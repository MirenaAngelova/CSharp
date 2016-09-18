namespace BoatRacingSimulator.Models.Races
{
    public class OpenRace
    {
        public OpenRace(int distance, int windSpeed, int oceanCurrentSpeed, bool allowsMotorboats)
        {
            this.Distance = distance;
            this.WindSpeed = windSpeed;
            this.OceanCurrentSpeed = oceanCurrentSpeed;
            this.AllowsMotorboats = allowsMotorboats;
        }

        public bool AllowsMotorboats { get; private set; }

        public int OceanCurrentSpeed { get; private set; }

        public int WindSpeed { get; private set; }

        public int Distance { get;private  set; }
    }
}