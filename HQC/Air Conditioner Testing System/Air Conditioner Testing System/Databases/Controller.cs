using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Air_Conditioner_Testing_System.Constants;
using Air_Conditioner_Testing_System.Enums;
using Air_Conditioner_Testing_System.Interfaces;
using Air_Conditioner_Testing_System.Models;
using Air_Conditioner_Testing_System.Models.AirConditioners;

namespace Air_Conditioner_Testing_System.Databases
{
    public class Controller : IController
    {
        public Controller(IDatabase database)
        {
            this.Database = database;
        }

        public Controller() : this(new Database())
        {
        }

        public IDatabase Database { get; private set; }

        public string RegisterStationaryAirConditioner(
            string manufacturer, string model, string energyEfficiencyRating, int powerUsage)
        {
            EnergyEfficiencyRating rating;
            try
            {
                rating =
                    (EnergyEfficiencyRating)Enum
                    .Parse(typeof(EnergyEfficiencyRating), energyEfficiencyRating);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(Constant.IncorrectEnergyRating, ex);
            }

            IAirConditioner airConditioner = new StationaryAirConditioner(
                                manufacturer, model, rating, powerUsage);

            this.Database.AirConditioners.Add(airConditioner);
            return string.Format(
                Constant.RegisterSuccessfully, airConditioner.Model, airConditioner.Manufacturer);
        }

        public string RegisterCarAirConditioner(string manufacturer, string model, int volumeCoverage)
        {
            IAirConditioner airConditioner = new CarAirConditioner(manufacturer, model, volumeCoverage);
            this.Database.AirConditioners.Add(airConditioner);
            return string.Format(
                Constant.RegisterSuccessfully, airConditioner.Model, airConditioner.Manufacturer);
        }

        public string RegisterPlaneAirConditioner(
            string manufacturer, string model, int volumeCovered, int electricityUsed)
        {
            IAirConditioner airConditioner =
                new PlaneAirConditioner(manufacturer, model, volumeCovered, electricityUsed);
            this.Database.AirConditioners.Add(airConditioner);
            return string.Format(
                Constant.RegisterSuccessfully, airConditioner.Model, airConditioner.Manufacturer);
        }

        public string TestAirConditioner(string manufacturer, string model)
        {
            IAirConditioner airConditioner = this.Database.AirConditioners.GetItem(manufacturer, model);
            Mark mark = airConditioner.Test() ? Mark.Passed : Mark.Failed;
            this.Database.Reports.Add(new Report(airConditioner.Manufacturer, airConditioner.Model, mark));
            return string.Format(Constant.TestedSuccessfully, model, manufacturer);
        }

        public string FindAirConditioner(string manufacturer, string model)
        {
            IAirConditioner airConditioner = this.Database.AirConditioners.GetItem(manufacturer, model);
            return airConditioner.ToString();
        }

        public string FindReport(string manufacturer, string model)
        {
            IReport report = this.Database.Reports.GetItem(manufacturer, model);
            return report.ToString();
        }

        public string FindAllReportsByManufacturer(string manufacturer)
        {
            IList<IReport> reports = this.Database.Reports.GetReportsByManufacturer(manufacturer);
            if (reports.Count == 0)
            {
                return Constant.NoReports;
            }

            reports = reports.OrderBy(x => x.Model).ToList();
            StringBuilder reportsPrint = new StringBuilder();
            reportsPrint.AppendLine(string.Format("Reports from {0}:", manufacturer));
            reportsPrint.Append(string.Join(Environment.NewLine, reports));
            return reportsPrint.ToString();
        }
        public string Status()
        {
            int reports = this.Database.Reports.Count;
            double airConditioners = this.Database.AirConditioners.Count;
            if (reports == 0)
            {
                return string.Format(Constant.Status, 0);
            }
            double percent = reports / airConditioners;
            percent = percent * 100;
            return string.Format(Constant.Status, percent);
        }
    }
}