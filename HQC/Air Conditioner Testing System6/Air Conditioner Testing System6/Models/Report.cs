using System.Text;
using Air_Conditioner_Testing_System6.Enums;
using Air_Conditioner_Testing_System6.Interfaces;

namespace Air_Conditioner_Testing_System6.Models
{
    public class Report : IReport
    {
        public Report(string manufacturer, string model, Mark mark)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Mark = mark;
        }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public Mark Mark { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("Report");
            result.AppendLine("====================");
            result.AppendLine($"Manufacturer: {this.Manufacturer}");
            result.AppendLine($"Model: {this.Model}");
            result.AppendLine($"Mark: {this.Mark}");
            result.Append("====================");

            return result.ToString();
        }
    }
}
