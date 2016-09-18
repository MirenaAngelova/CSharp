namespace BoatRacingSimulator.Models.Boats.MotorBoats
{
    using Interfaces;

    public class PowerBoat : MotorBoat
    {
        public PowerBoat(string model, int weight, IBoatEngine firstEngine, IBoatEngine secondEngine) 
            : base(model, weight, firstEngine)
        {
            this.FirstEngine = firstEngine;
            this.SecondEngine = secondEngine;
        }

        public IBoatEngine SecondEngine { get; private set; }

        public IBoatEngine FirstEngine { get; private set; }

        public override double CalculateRaceSpeed(IRace race)
        {
            var speed = this.FirstEngine.+ this.SecondEngine. - 
                this.Weight + (race.OceanCurrentSpeed / 5d);
            return speed;
        }
    }
}