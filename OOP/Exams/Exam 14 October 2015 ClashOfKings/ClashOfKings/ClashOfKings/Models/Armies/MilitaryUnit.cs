namespace ClashOfKings.Models.Armies
{
    using System;

    using Contracts;

    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private int armor;
        private int damage;
        private decimal trainingCost;
        private double upkeepCost;
        private int housingSpacesRequired;

        protected MilitaryUnit(
            int armor, 
            int damage, 
            decimal trainingCost, 
            double upkeepCost, 
            int housingSpacesRequired, 
            UnitType type)
        {
            this.Armor = armor;
            this.Damage = damage;
            this.TrainingCost = trainingCost;
            this.UpkeepCost = upkeepCost;
            this.HousingSpacesRequired = housingSpacesRequired;
            this.Type = type;
        }

        public int Armor
        {
            get
            {
                return this.armor;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.armor), "The armor cannot be negative.");
                }

                this.armor = value;
            }
        }

        public int Damage
        {
            get
            {
                return this.damage;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.damage), "The damage cannot be negative.");
                }
                this.damage = value;
            }
            
        }

        public decimal TrainingCost
        {
            get
            {
                return this.trainingCost;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.trainingCost),
                        "The training cost cannot be negtive.");
                }

                this.trainingCost = value;
            }
        }

        public double UpkeepCost
        {
            get
            {
                return this.upkeepCost;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.upkeepCost), "The upkeep cost cannot be negative.");
                }

                this.upkeepCost = value;
            }
        }

        public int HousingSpacesRequired
        {
            get
            {
                return this.housingSpacesRequired;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.housingSpacesRequired),
                        "The housing space required cannot be negative.");
                }

                this.housingSpacesRequired = value;
            }
        }

        public UnitType Type { get; private set; }
    }
}
