using System;
using System.Text;
using Air_Conditioner_Testing_System.Constants;

namespace Air_Conditioner_Testing_System.Models.AirConditioners
{
    public class CarAirConditioner : VehicleAirCondotioner
    {
        public CarAirConditioner(string manufacturer, string model, int volumeCovered) 
            : base(manufacturer, model, volumeCovered)
        {
        }

        public override bool Test()
        {//square root of the volume covered is less than 3 the test fails
            double sqrtVolume = Math.Sqrt(this.volumeCovered);
            if (sqrtVolume < Constant.MinCarVolume)
            {
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(base.ToString());
            result.AppendLine($"Volume Covered: {this.VolumeCovered}");
            result.AppendLine("====================");

            return result.ToString();
        }
    }
}