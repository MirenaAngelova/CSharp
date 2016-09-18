using System;
using Air_Conditioner_Testing_System.Databases;
using Air_Conditioner_Testing_System.Enums;
using Air_Conditioner_Testing_System.Exceptions;
using Air_Conditioner_Testing_System.Interfaces;
using Air_Conditioner_Testing_System.Models.AirConditioners;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Air_Conditioner_Testing_System.Test
{
    [TestClass]
    public class RepositoryAddTests
    {
        private IRepository<IAirConditioner> Repository { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            this.Repository = new Repository<IAirConditioner>();
        }

        [TestMethod]
        public void AddRepository_WithCorrectInput_ShouldReturnCountOfAddItems()
        {
            IAirConditioner airConditionerS1 = new StationaryAirConditioner("Toshiba", "EX10", EnergyEfficiencyRating.B, 1000);
            IAirConditioner airConditionerS2 = new StationaryAirConditioner("Toshiba", "EX11", EnergyEfficiencyRating.B, 1000);
            IAirConditioner airConditionerS3 = new StationaryAirConditioner("Toshiba", "EX12", EnergyEfficiencyRating.B, 1000);

            IAirConditioner airConditionerP1 = new PlaneAirConditioner("Hitachi", "HZ200", 25, 70);
            IAirConditioner airConditionerP2 = new PlaneAirConditioner("Hitachi", "HZ201", 25, 70);
            IAirConditioner airConditionerP3 = new PlaneAirConditioner("Hitachi", "HZ202", 25, 70);

            this.Repository.Add(airConditionerS1);
            this.Repository.Add(airConditionerS2);
            this.Repository.Add(airConditionerS3);

            this.Repository.Add(airConditionerP1);
            this.Repository.Add(airConditionerP2);
            this.Repository.Add(airConditionerP3);

            var actual = this.Repository.Count;

            var expected = 6;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddRepository_WithCorrectInput2_ShouldReturnCountOfAddItems()
        {
            IAirConditioner airConditionerS1 = new StationaryAirConditioner("Toshiba", "EX10", EnergyEfficiencyRating.B, 1000);
            IAirConditioner airConditionerS2 = new StationaryAirConditioner("Toshiba", "EX11", EnergyEfficiencyRating.B, 1000);
            IAirConditioner airConditionerS3 = new StationaryAirConditioner("Toshiba", "EX12", EnergyEfficiencyRating.B, 1000);

            IAirConditioner airConditionerP1 = new PlaneAirConditioner("Hitachi", "HZ200", 25, 70);
            IAirConditioner airConditionerP2 = new PlaneAirConditioner("Hitachi", "HZ201", 25, 70);
            IAirConditioner airConditionerP3 = new PlaneAirConditioner("Hitachi", "HZ202", 25, 70);

            this.Repository.Add(airConditionerP3);

            var actual = this.Repository.Count;

            var expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddRepository_WithDuplicateEntry_ShouldThrowAppropriateExceptionMessage()
        {
            IAirConditioner airConditionerS1 = new StationaryAirConditioner("Toshiba", "EX10", EnergyEfficiencyRating.B, 1000);
            IAirConditioner airConditionerS2 = new StationaryAirConditioner("Toshiba", "EX10", EnergyEfficiencyRating.B, 1000);
            IAirConditioner airConditionerS3 = new StationaryAirConditioner("Toshiba", "EX12", EnergyEfficiencyRating.B, 1000);

            IAirConditioner airConditionerP1 = new PlaneAirConditioner("Hitachi", "HZ200", 25, 70);
            IAirConditioner airConditionerP2 = new PlaneAirConditioner("Hitachi", "HZ201", 25, 70);
            IAirConditioner airConditionerP3 = new PlaneAirConditioner("Hitachi", "HZ202", 25, 70);
            this.Repository.Add(airConditionerS1);
            var actual = string.Empty;
            try
            {
                this.Repository.Add(airConditionerS2);
            }
            catch (DuplicateEntryException e)
            {
                actual = e.Message;
            }

            this.Repository.Add(airConditionerS3);
            this.Repository.Add(airConditionerP1);
            this.Repository.Add(airConditionerP2);
            this.Repository.Add(airConditionerP3);

            var expected = "An entry for the given model already exists.";

            Assert.AreEqual(expected, actual);
        }

        [ExpectedException(typeof(DuplicateEntryException))]
        [TestMethod]
        public void AddRepository_WithDuplicateEntry2_ShouldThrowAppropriateExceptionMessage()
        {
            IAirConditioner airConditionerS1 = new StationaryAirConditioner("Toshiba", "EX10", EnergyEfficiencyRating.B, 1000);
            IAirConditioner airConditionerS2 = new StationaryAirConditioner("Toshiba", "EX11", EnergyEfficiencyRating.B, 1000);
            IAirConditioner airConditionerS3 = new StationaryAirConditioner("Toshiba", "EX12", EnergyEfficiencyRating.B, 1000);

            IAirConditioner airConditionerP1 = new PlaneAirConditioner("Hitachi", "HZ200", 25, 70);
            IAirConditioner airConditionerP2 = new PlaneAirConditioner("Hitachi", "HZ201", 25, 70);
            IAirConditioner airConditionerP3 = new PlaneAirConditioner("Hitachi", "HZ201", 25, 70);
            this.Repository.Add(airConditionerS1);
            this.Repository.Add(airConditionerS2);
            this.Repository.Add(airConditionerS3);
            this.Repository.Add(airConditionerP1);
            this.Repository.Add(airConditionerP2);

            this.Repository.Add(airConditionerP3);
        }
    }
}
