namespace BoatRacingSimulator.Tests
{
    using System;
    using Controllers;
    using Exceptions;
    using Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class OpenRaceTests
    {
        private IBoatSimulatorController Controller { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            this.Controller = new BoatSimulatorController();
        }

        [TestMethod]
        public void OpenRace_WithCorrectInput_ShouldReturnAppropriateMessage()
        {
            var actual = this.Controller.OpenRace(1000, 10, 5, true);

            var expected =
                "A new race with distance 1000 meters, wind speed 10 m/s " +
                "and ocean current speed 5 m/s has been set.";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OpenRace_WithInvalidDistance_ShouldThrowAppropriateExceptionMessage()
        {
            try
            {
                this.Controller.OpenRace(-1000, 10, 5, true);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Distance must be a positive integer.", ex.Message);
            }
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void OpenRace_WithInvalidDistance_ShouldThrowArgumentException()
        {
            this.Controller.OpenRace(-1000, 10, 5, true);
        }

        [TestMethod]
        public void OpenRace_WithDuplicateEntry_ShouldThrowAppropriateExceptionMessage()
        {
            try
            {
                this.Controller.OpenRace(1000, 10, 5, true);
                this.Controller.OpenRace(1000, 10, 5, true);
            }
            catch (RaceAlreadyExistsException ex)
            {
                Assert.AreEqual("The current race has already been set.", ex.Message);
            }
        }

        [ExpectedException(typeof(RaceAlreadyExistsException))]
        [TestMethod]
        public void OpenRace_WithDuplicateEntry_ShouldThrowRaceAlreadyExistsException()
        {
            this.Controller.OpenRace(1000, 10, 5, true);
            this.Controller.OpenRace(1000, 10, 5, true);
        }
    }
}
