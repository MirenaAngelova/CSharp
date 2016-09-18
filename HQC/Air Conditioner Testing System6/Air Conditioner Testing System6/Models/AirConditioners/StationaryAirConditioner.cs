using System;
using System.Text;
using Air_Conditioner_Testing_System6.Constants;
using Air_Conditioner_Testing_System6.Enums;

namespace Air_Conditioner_Testing_System6.Models.AirConditioners
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

        public EnergyEfficiencyRating EnergyEfficiencyRating { get;}

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
                    throw new ArgumentOutOfRangeException(
                        string.Format(Constant.NonPositive, "Power Usage"));
                }

                this.powerUsage = value;
            }
        }

       
        public override bool Test()
        {
            if (this.PowerUsage <=  (int)this.EnergyEfficiencyRating||
                this.EnergyEfficiencyRating == EnergyEfficiencyRating.E)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(base.ToString());
            result.AppendFormat($"Required energy efficiency rating: {this.EnergyEfficiencyRating}");
            result.AppendFormat($"Power Usage(KW / h): {this.PowerUsage}");
            result.AppendFormat("====================");

            return result.ToString();
        }
    }
}