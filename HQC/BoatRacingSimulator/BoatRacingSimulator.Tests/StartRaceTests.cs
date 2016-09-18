namespace BoatRacingSimulator.Tests
{
    using Controllers;
    using Exceptions;
    using Interfaces;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    [TestClass]
    public class StartRaceTests
    {
        private IBoatSimulatorController Controller { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            this.Controller = new BoatSimulatorController();
        }

        [TestMethod]
        public void StartRace_WithNoSetRace_ShouldThrowExceptionMessage()
        {
            try
            {
                this.Controller.CurrentRace = null;
            }
            catch (NoSetRaceException ex)
            {
                
               Assert.AreEqual("There is currently no race set.", ex.Message);
            }
        }

        [ExpectedException(typeof(NoSetRaceException))]
        [TestMethod]
        public void StartRace_WithNoSetRace_ShouldThrowNoSetRaceException()
        {
             this.Controller.CurrentRace = null;
        }

        [TestMethod]
        public void StartRace_WithInCorrectParticipantsCount_ShouldThrowExceptionMessage()
        {
            try
            {
                this.Controller.CurrentRace.GetParticipants();
            }
            catch (InsufficientContestantsException ex)
            {

                Assert.AreEqual("Not enough contestants for the race.", ex.Message);
            }
        }
    }
}
