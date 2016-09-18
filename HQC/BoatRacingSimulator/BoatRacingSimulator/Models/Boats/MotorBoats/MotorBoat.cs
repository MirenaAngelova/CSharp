namespace BoatRacingSimulator.Models.Boats.MotorBoats
{
    using Interfaces;

    public abstract class MotorBoat : Boat
    {
        protected MotorBoat(string model, int weight, IBoatEngine boatEngine) : base(model, weight)
        {
            this.BoatEngine = boatEngine;
        }

        public IBoatEngine BoatEngine { get; protected set; }
    }
}