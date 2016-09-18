namespace BoatRacingSimulator.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Database;
    using Enumerations;
    using Exceptions;
    using Interfaces;
    using Utility;
    using Models.Boats;
    using Models.Boats.MotorBoats;
    using Models.Engines;
    using Models.Races;

    public class BoatSimulatorController : IBoatSimulatorController
    {
        public BoatSimulatorController(IBoatSimulatorDatabase database, IRace currentRace)
        {
            this.Database = database;
            this.CurrentRace = currentRace;
        }

        public BoatSimulatorController() : this(new BoatSimulatorDatabase(), null)
        {
        }

        public IRace CurrentRace { get; private set; }

        public IBoatSimulatorDatabase Database { get; private set; }

        public string CreateBoatEngine(
            string model, int horsePower, int displacement, EngineType engineType)
        {
            IBoatEngine engine;
            switch (engineType)
            {
                case EngineType.Jet:
                    engine = new JetEngine(model, horsePower, displacement);
                    break;
                case EngineType.Sterndrive:
                    engine = new SterndriveEngine(model, horsePower, displacement);
                    break;
                default:
                    throw new IncorrectEngineTypeException(Constants.IncorrectEngineTypeMessage);
            }

            this.Database.Engines.Add(engine);
            return string.Format(
                Constants.EngineCreatedSuccessfully,
                model,
                horsePower,
                displacement);
        }

        public string CreateRowBoat(string model, int weight, int oars)
        {
            IBoat boat = new RowBoat(model, weight, oars);
            this.Database.Boats.Add(boat);
            return string.Format(Constants.BoatRegisteredSuccessfully, "Row", model);
        }

        public string CreateSailBoat(string model, int weight, int sailEfficiency)
        {
            IBoat boat = new SailBoat(model, weight, sailEfficiency);
            this.Database.Boats.Add(boat);
            return string.Format(Constants.BoatRegisteredSuccessfully, "Sail", model);
        }

        public string CreatePowerBoat(
            string model, int weight, string firstEngineModel, string secondEngineModel)
        {
            IBoatEngine firstEngine = this.Database.Engines.GetItem(firstEngineModel) as JetEngine;
            IBoatEngine secondEngine = this.Database.Engines.GetItem(secondEngineModel) as SterndriveEngine;
            IBoat boat = new PowerBoat(model, weight,firstEngine, secondEngine);
            this.Database.Boats.Add(boat);
            return string.Format(Constants.BoatRegisteredSuccessfully,"Power", model);
        }

        public string CreateYacht(string model, int weight, string engineModel, int cargoWeight)
        {
            IBoatEngine engine =
                (EngineType) Enum.Parse(typeof (EngineType), engineModel) == EngineType.Jet
                    ? (IBoatEngine) (this.Database.Engines.GetItem(engineModel) as JetEngine)
                    : this.Database.Engines.GetItem(engineModel) as SterndriveEngine;
            IBoat boat = new Yacht(model, weight, engine, cargoWeight);
            this.Database.Boats.Add(boat);
            return string.Format(Constants.BoatRegisteredSuccessfully, "Yacht", model);
        }

        public string OpenRace(int distance, int windSpeed, int oceanCurrentSpeed, bool allowsMotorboats)
        {
            IRace race = new Race(distance, windSpeed, oceanCurrentSpeed, allowsMotorboats);
            this.ValidateRaceIsEmpty();
            this.CurrentRace = race;
            return
                string.Format(Constants.NewRaceSet, distance, windSpeed, oceanCurrentSpeed);
        }

        public string SignUpBoat(string model)
        {
            IBoat boat = this.Database.Boats.GetItem(model);
            this.ValidateRaceIsSet();
            if (!this.CurrentRace.AllowsMotorboats && boat is IBoat)
            {
                throw new ArgumentException(Constants.IncorrectBoatTypeMessage);
            }

            this.CurrentRace.AddParticipant(boat);
            return string.Format(Constants.BoatSignedUp, model);
        }

        public string StartRace()
        {
            this.ValidateRaceIsSet();
            var participants = this.CurrentRace.GetParticipants();
            if (participants.Count < Constants.MinParticipantsCount)
            {
                throw new InsufficientContestantsException(Constants.InsufficientContestantsMessage);
            }

            var first = this.FindFastest(participants);
            participants.Remove(first.Value);
            var second = this.FindFastest(participants);
            participants.Remove(second.Value);
            var third = this.FindFastest(participants);
            participants.Remove(third.Value);

            var result = new StringBuilder();
            result.AppendLine(string.Format(
                "First place: {0} Model: {1} Time: {2}",
                first.Value.GetType().Name,
                first.Value.Model,
                Double.IsInfinity(first.Key) ? "Did not finish!" : first.Key.ToString("0.00") + " sec"));
            result.AppendLine(string.Format(
                "Second place: {0} Model: {1} Time: {2}",
                second.Value.GetType().Name,
                second.Value.Model,
                Double.IsInfinity(second.Key) ? "Did not finish!" : second.Key.ToString("0.00") + " sec"));
            result.Append(string.Format(
                "Third place: {0} Model: {1} Time: {2}",
                third.Value.GetType().Name,
                third.Value.Model,
                Double.IsInfinity(third.Key) ? "Did not finish!" : third.Key.ToString("0.00") + " sec"));

            this.CurrentRace = null;

            return result.ToString();
        }

        public string GetStatistic()
        {
            //TODO Bonus Task Implement me
            throw new NotImplementedException();
        }

        private KeyValuePair<double, IBoat> FindFastest(IList<IBoat> participants)
        {
            double bestTime = 0; 
            IBoat winner = null;
            foreach (var participant in participants)
            {
                var speed = participant.CalculateRaceSpeed(this.CurrentRace);
                var time = this.CurrentRace.Distance/speed;
                if (time < bestTime)
                {
                    bestTime = time;
                    winner = participant;
                }
            }

            return new KeyValuePair<double, IBoat>(bestTime,winner);
        }

        private void ValidateRaceIsSet()
        {
            if (this.CurrentRace == null)
            {
                throw new NoSetRaceException(Constants.NoSetRaceMessage);
            }
        }

        private void ValidateRaceIsEmpty()
        {
            if (this.CurrentRace != null)
            {
                throw new RaceAlreadyExistsException(Constants.RaceAlreadyExistsMessage);
            }
        }
    }
}
