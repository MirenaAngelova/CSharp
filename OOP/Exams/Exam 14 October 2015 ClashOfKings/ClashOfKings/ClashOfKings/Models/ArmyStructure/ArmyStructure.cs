namespace ClashOfKings.Models.ArmyStructure
{
    using System;

    using Contracts;
    using Armies;

    public abstract class ArmyStructure : IArmyStructure
    {
        private decimal buildCost;
        private int capacity;

        protected ArmyStructure(CityType requiredCityType, decimal buildCost, int capacity, UnitType unitType)
        {
            this.RequiredCityType = requiredCityType;
            this.BuildCost = buildCost;
            this.Capacity = capacity;
            this.UnitType = unitType;
        }

        public CityType RequiredCityType { get; private set; }

        public decimal BuildCost
        {
            get
            {
                return this.buildCost;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.buildCost), 
                        "The build cost cannot be negative.");
                }

                this.buildCost = value;
            }
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.capacity),
                        "The capacity cannot be negative.");
                }

                this.capacity = value;
            }
        }

        public UnitType UnitType { get; private set; }
    }
}
