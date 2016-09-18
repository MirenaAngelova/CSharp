namespace BoatRacingSimulator.Interfaces
{
    using Enumerations;

    public interface IBoatSimulatorController
    {
        IRace CurrentRace { get; set; }

        IBoatSimulatorDatabase Database { get; }

        string CreateBoatEngine(string model, int horsePower, int displacement, EngineType engineType);

        string CreateRowBoat(string model, int weight, int oars);

        string CreateSailBoat(string model, int weight, int sailEfficiency);

        string CreatePowerBoat(string model, int weight, string firstEngineModel, string secondEngineModel);

        string CreateYacht(string model, int weight, string engineModel, int cargoWeight);

        string OpenRace(int distance, int windSpeed, int oceanCurrentSpeed, bool allowsMotorboats);

        string SignUpBoat(string model);

        string StartRace();

        string GetStatistic();
    }
}
