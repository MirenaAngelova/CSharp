namespace BoatRacingSimulator.Database
{
    using Interfaces;

    public class BoatSimulatorDatabase : IBoatSimulatorDatabase
    {
        public BoatSimulatorDatabase()
        {
            this.Boats = new Repository<IBoat>();
            this.Engines = new Repository<IModelable>();
        }

        public IRepository<IBoat> Boats { get; private set; }

        public IRepository<IModelable> Engines { get; private set; }
    }
}
