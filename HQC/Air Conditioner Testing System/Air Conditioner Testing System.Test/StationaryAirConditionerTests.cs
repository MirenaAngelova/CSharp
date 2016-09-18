using System;
using Air_Conditioner_Testing_System.Databases;
using Air_Conditioner_Testing_System.Enums;
using Air_Conditioner_Testing_System.Interfaces;
using Air_Conditioner_Testing_System.Models.AirConditioners;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Air_Conditioner_Testing_System.Test
{
    [TestClass]
    public class StationaryAirConditionerTests
    {
        private IController controller;

        [TestInitialize]
        public void Initialize()
        {
            this.controller = new Controller();
        }

        [TestMethod]
        public void Register_WithCorrectInput_ShouldReturnSuccessfulMessage()
        {//RegisterStationaryAirConditioner (Toshiba,EX1000,B,1000)
            var actual =
                this.controller.RegisterStationaryAirConditioner("Toshiba", "EX10", "B", 1000);

            var expected = "Air Conditioner model EX10 from Toshiba registered successfully.";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Register_WithInCorrectManufacturer_ShouldThrowAppropriateMessage()
        {//RegisterStationaryAirConditioner (Toshiba,EX1000,B,1000)
            string actual;
            try
            {
                actual =
                         this.controller.RegisterStationaryAirConditioner("Tos", "EX10", "B", 1000);
            }
            catch (Exception e)
            {

                actual = e.Message;
            }

            var expected = "Manufacturer's name must be at least 4 symbols long.";

            Assert.AreEqual(expected, actual);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void Register_WithInCorrectManufacturer_ShouldThrowArgumentException()
        {//RegisterStationaryAirConditioner (Toshiba,EX1000,B,1000)

            this.controller.RegisterStationaryAirConditioner("Tos", "EX10", "B", 1000);
        }

        [TestMethod]
        public void Register_WithEmptytManufacturer_ShouldThrowAppropriateMessage()
        {//RegisterStationaryAirConditioner (Toshiba,EX1000,B,1000)
            string actual;
            try
            {
                actual =
                         this.controller.RegisterStationaryAirConditioner("", "EX10", "B", 1000);
            }
            catch (Exception e)
            {

                actual = e.Message;
            }

            var expected = "Manufacturer's name must be at least 4 symbols long.";

            Assert.AreEqual(expected, actual);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void Register_WithEmptytManufacturer_ShouldThrowArgumentException()
        {//RegisterStationaryAirConditioner (Toshiba,EX1000,B,1000)

            this.controller.RegisterStationaryAirConditioner("", "EX10", "B", 1000);
        }

        [TestMethod]
        public void Register_WithInCorrectModel_ShouldThrowAppropriateMessage()
        {//RegisterStationaryAirConditioner (Toshiba,EX1000,B,1000)
            string actual;
            try
            {
                actual =
                         this.controller.RegisterStationaryAirConditioner("Toshiba", "E", "B", 1000);
            }
            catch (Exception e)
            {

                actual = e.Message;
            }

            var expected = "Model's name must be at least 2 symbols long.";

            Assert.AreEqual(expected, actual);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void Register_WithIncorrectModel_ShouldThrowArgumentException()
        {//RegisterStationaryAirConditioner (Toshiba,EX1000,B,1000)

            this.controller.RegisterStationaryAirConditioner("Toshiba", "E", "B", 1000);
        }

        [TestMethod]
        public void Register_WithInCorrecRating_ShouldThrowAppropriateMessage()
        {//RegisterStationaryAirConditioner (Toshiba,EX1000,B,1000)
            string actual;
            try
            {
                actual =
                         this.controller.RegisterStationaryAirConditioner("Toshiba", "EX10", "M", 1000);
            }
            catch (Exception e)
            {

                actual = e.Message;
            }

            var expected = "Energy efficiency rating must be between \"A\" and \"E\".";

            Assert.AreEqual(expected, actual);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void Register_WithIncorrectRating_ShouldThrowArgumentException()
        {//RegisterStationaryAirConditioner (Toshiba,EX1000,B,1000)

            this.controller.RegisterStationaryAirConditioner("Toshiba", "EX10", "M", 1000);
        }

        [TestMethod]
        public void Register_WithInCorrecPowerUsage_ShouldThrowAppropriateMessage()
        {//RegisterStationaryAirConditioner (Toshiba,EX1000,B,1000)
            string actual;
            try
            {
                actual =
                         this.controller.RegisterStationaryAirConditioner("Toshiba", "EX10", "B", -1000);
            }
            catch (Exception e)
            {

                actual = e.Message;
            }

            var expected = "Power Usage must be a positive integer.";

            Assert.AreEqual(expected, actual);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void Register_WithIncorrectPowerUsage_ShouldThrowArgumentException()
        {//RegisterStationaryAirConditioner (Toshiba,EX1000,B,1000)

            this.controller.RegisterStationaryAirConditioner("Toshiba", "EX10", "B", -1000);
        }
    }
}
