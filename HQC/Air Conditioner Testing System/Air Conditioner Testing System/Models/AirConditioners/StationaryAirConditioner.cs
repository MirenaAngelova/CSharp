using System;
using System.Text;
using Air_Conditioner_Testing_System.Constants;
using Air_Conditioner_Testing_System.Enums;

namespace Air_Conditioner_Testing_System.Models.AirConditioners
{
    public class StationaryAirConditioner : AirConditioner
    {
        private int powerUsage;

        public StationaryAirConditioner(
            string manufacturer, 
            string model,
            EnergyEfficiencyRating energyEfficiencyRating, 
            int powerUsage) 
            : base(manufacturer, model)
        {
            this.EnergyEfficiencyRating = energyEfficiencyRating;
            this.PowerUsage = powerUsage;
        }

        public int PowerUsage
        {
            get
            {
                return this.powerUsage;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(Constant.NonPositive, "Power Usage"));
                }

                this.powerUsage = value;
            }
        }

        public EnergyEfficiencyRating EnergyEfficiencyRating { get; set; }

        public override bool Test()
        {
            if (this.PowerUsage  <= (int) this.EnergyEfficiencyRating || 
                this.EnergyEfficiencyRating == EnergyEfficiencyRating.E)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(base.ToString());
            result.AppendLine($"Required energy efficiency rating: {this.EnergyEfficiencyRating}");
            result.AppendLine($"Power Usage(KW / h): {this.PowerUsage}");
            result.AppendLine("====================");

            return result.ToString();
        }
    }
}