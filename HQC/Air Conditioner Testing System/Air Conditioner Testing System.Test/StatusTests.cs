using System;
using Air_Conditioner_Testing_System.Databases;
using Air_Conditioner_Testing_System.Enums;
using Air_Conditioner_Testing_System.Interfaces;
using Air_Conditioner_Testing_System.Models;
using Air_Conditioner_Testing_System.Models.AirConditioners;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Air_Conditioner_Testing_System.Test
{
    [TestClass]
    public class StatusTests
    {
        private IController Controller { get; set; }
        private IDatabase Database { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            this.Controller = new Controller();
            this.Database = new Database();
        }

        [TestMethod]
        public void Status_WithNoReports_ShouldReturnMessage()
        {
            IAirConditioner airConditioner = new StationaryAirConditioner("Toshiba", "EX100", EnergyEfficiencyRating.B, 1000);
            this.Database.AirConditioners.Add(airConditioner);

            var actual = this.Controller.Status();

            var expected = "Jobs complete: 0.00%";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Status_WithCorrectInput_ShouldReturnMessage()
        {
            IAirConditioner airConditioner = new StationaryAirConditioner("Toshiba", "EX100", EnergyEfficiencyRating.B, 1000);
            IReport report = new Report("Toshiba", "EX100", Mark.Passed);
            this.Database.AirConditioners.Add(airConditioner);
            this.Database.Reports.Add(report);

            var actual = this.Controller.Status();

            var expected = "Jobs complete: 0.00%";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Status_WithCorrectInput2_ShouldReturnMessage()
        {
            IAirConditioner airConditionerS1 = new StationaryAirConditioner("Toshiba", "EX100", EnergyEfficiencyRating.B, 1000);
            IAirConditioner airConditionerS2 = new StationaryAirConditioner("Toshiba", "EX101", EnergyEfficiencyRating.A, 1000);
            IReport reportS1 = new Report("Toshiba", "EX100", Mark.Passed);
            IReport reportS2 = new Report("Toshiba", "EX101", Mark.Failed);
            this.Database.AirConditioners.Add(airConditionerS1);
            this.Database.AirConditioners.Add(airConditionerS2);
            this.Database.Reports.Add(reportS1);
            this.Database.Reports.Add(reportS2);

            var actual = this.Controller.Status();

            var expected = "Jobs complete: 0.00%";
            Assert.AreEqual(expected, actual);
        }
    }
}
