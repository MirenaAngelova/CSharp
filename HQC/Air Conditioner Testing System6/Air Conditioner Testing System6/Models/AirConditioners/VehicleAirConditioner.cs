using System;
using System.Text;
using Air_Conditioner_Testing_System6.Constants;

namespace Air_Conditioner_Testing_System6.Models.AirConditioners
{
    public abstract class VehicleAirConditioner : AirConditioner
    {
        private int volumeCovered;

        protected VehicleAirConditioner(string manufacturer, string model, int volumeCovered)
            : base(manufacturer, model)
        {
            this.VolumeCovered = volumeCovered;
        }

        public int VolumeCovered
        {
            get
            {
                return this.volumeCovered;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(Constant.NonPositive, "Volume Covered"));
                }

                this.volumeCovered = value;
            }
        }
        
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(base.ToString());
            result.AppendLine($"Volume Covered: {this.VolumeCovered}");

            return result.ToString();
        }
    }
}