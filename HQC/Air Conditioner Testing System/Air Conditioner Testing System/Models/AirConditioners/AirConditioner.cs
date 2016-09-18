using System;
using System.Text;
using Air_Conditioner_Testing_System.Constants;
using Air_Conditioner_Testing_System.Interfaces;

namespace Air_Conditioner_Testing_System.Models.AirConditioners
{
    public abstract class AirConditioner : IAirConditioner
    {
        private string manufacturer;
        private string model;

        protected AirConditioner(string manufacturer, string model)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < Constant.ManufacturerMinLength)
                {
                    throw new ArgumentException(string.Format(
                        Constant.IncorrectPropertyLength, "Manufacturer", Constant.ManufacturerMinLength));
                }

                this.manufacturer = value;
            }
        }
        
        public string Model
        {
            get
            {
                return this.model;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < Constant.ModelMinLength)
                {
                    throw new ArgumentException(string.Format
                        (Constant.IncorrectPropertyLength, "Model", Constant.ModelMinLength));
                }

                this.model = value;
            }
        }

        public abstract bool Test();

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("Air Conditioner");
            result.AppendLine("====================");
            result.AppendLine($"Manufacturer: {this.Manufacturer}");
            result.AppendLine($"Model: {this.Model}");

            return result.ToString();
        }
    }
}