namespace BoatRacingSimulator.Models.Engines
{
    using Interfaces;
    using Utility;

    public abstract class BoatEngine : IBoatEngine
    {
        private string model;

        private int horsepower;

        private int displacement;

        protected BoatEngine(string model, int horsepower, int displacement)
        {
            this.Model = model;
            this.Horsepower = horsepower;
            this.Displacement = displacement;
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            private set
            {
                Validator.ValidateModelLength(value, Constants.MinBoatEngineModelLength);
                this.model = value;
            }
        }

        public int Horsepower
        {
            get
            {
                return this.horsepower;
            }

            protected set
            {
                Validator.ValidatePropertyValue(value, "Horsepower");
                this.horsepower = value;
            }
        }

        public int Displacement
        {
            get
            {
                return this.displacement;
            }

            protected set
            {
                Validator.ValidatePropertyValue(value, "Displacement");
                this.displacement = value;
            }
        }

        public virtual int Output { get; set; }
    }
}
