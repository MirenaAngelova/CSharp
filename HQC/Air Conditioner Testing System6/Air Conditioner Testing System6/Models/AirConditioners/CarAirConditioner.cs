using System;
using System.Text;
using Air_Conditioner_Testing_System6.Constants;

namespace Air_Conditioner_Testing_System6.Models.AirConditioners
{
    public class CarAirConditioner : VehicleAirConditioner
    {
        public CarAirConditioner(string manufacturer, string model, int volumeCovered) 
            : base(manufacturer, model, volumeCovered)
        {
        }

        public override bool Test()
        {
            double sqrtVolume = Math.Sqrt(this.VolumeCovered);
            if (sqrtVolume < Constant.MinCarVolume)
            {
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(base.ToString());
            result.AppendLine("====================");
            return result.ToString();
        }
    }
}