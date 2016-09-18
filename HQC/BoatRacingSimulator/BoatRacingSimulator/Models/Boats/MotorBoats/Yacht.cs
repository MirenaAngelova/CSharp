namespace BoatRacingSimulator.Models.Boats.MotorBoats
{
    using Interfaces;
    using Utility;

    public class Yacht : MotorBoat
    {
        private int cargoWeight;

        public Yacht(string model, int weight, IBoatEngine boatEngine, int cargoWeight) 
            : base(model, weight, boatEngine)
        {
            this.CargoWeight = cargoWeight;
        }

        public int CargoWeight
        {
            get
            {
                return this.cargoWeight;
            }

            private set
            {
                Validator.ValidatePropertyValue(value, "Cargo Weight");
                this.cargoWeight = value;
            }
        }

        public override double CalculateRaceSpeed(IRace race)
        {
            var speed = this.JetEngines.Sum(x => x.Output) +
                this.SterndriveEngines.Sum(x => x.Output) - 
                this.Weight - this.CargoWeight + 
                (race.OceanCurrentSpeed / 2d);
            return speed;
        }
    }
}