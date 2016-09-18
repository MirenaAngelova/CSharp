using System;
using Air_Conditioner_Testing_System.Constants;

namespace Air_Conditioner_Testing_System.Models.AirConditioners
{
    public abstract class VehicleAirCondotioner : AirConditioner
    {
        protected int volumeCovered;

        protected VehicleAirCondotioner(string manufacturer, string model, int volumeCovered) 
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
    }
}