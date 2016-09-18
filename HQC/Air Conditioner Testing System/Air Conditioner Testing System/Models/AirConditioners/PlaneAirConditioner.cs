using System;
using System.Text;
using Air_Conditioner_Testing_System.Constants;

namespace Air_Conditioner_Testing_System.Models.AirConditioners
{
    public class PlaneAirConditioner : VehicleAirCondotioner
    {
        private int electricityUsed;

        public PlaneAirConditioner(
            string manufacturer, 
            string model, 
            int volumeCovered,
            int electricityUsed) 
            : base(manufacturer, model, volumeCovered)
        {
            this.ElectricityUsed = electricityUsed;
        }

        public int ElectricityUsed
        {
            get
            {
                return this.electricityUsed;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(Constant.NonPositive, "Electricity Used"));
                }

                this.electricityUsed = value;
            }
        }
        public override bool Test()
        {
            double sqrtVolume = Math.Sqrt(this.volumeCovered);
            if (this.ElectricityUsed / sqrtVolume < Constant.MinPlaneElectricity)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
           StringBuilder result = new StringBuilder();
            result.Append(base.ToString());
            result.AppendLine($"Volume Covered: {this.VolumeCovered}");
            result.AppendLine($"Electricity Used: {this.ElectricityUsed}");
            result.AppendLine("====================");

            return result.ToString();
        }
    }
}