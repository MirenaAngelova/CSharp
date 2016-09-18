namespace BoatRacingSimulator.Models.Engines
{
    using Utility;

    public class JetEngine : BoatEngine
    {
        public JetEngine(string model, int horsepower, int displacement) 
            : base(model, horsepower, displacement)
        {
        }

        public override int Output
        {
            get
            {
                if (this.CachedOutput != 0)
                {
                    return this.CachedOutput;
                }

                this.CachedOutput = (this.Horsepower * Constants.JetEngineMultiplier) + this.Displacement;
                return this.CachedOutput;
            }
        }

        protected int CachedOutput { get; set; }
    }
}