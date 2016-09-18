namespace ClashOfKings
{
    using Contracts;
    using Engine;
    using Engine.Factories;
    using UI;

    public class ClashOfKingsMain
    {
        public static void Main()
        {
            IInputController inputController = new ConsoleInputController();
            IRenderer renderer = new ConsoleRenderer();

            IUnitFactory unitFactory = new UnitFactory();
            IArmyStructureFactory armyStructureFactory = new ArmyStructureFactory();
            ICommandFactory commandFactory = new CommandFactory();

            IContinent westeros = new ExtendedWesteros();

            IGameEngine engine = new WarEngine(
                renderer,
                inputController,
                unitFactory,
                armyStructureFactory,
                commandFactory,
                westeros);

            engine.Run();
        }
    }
}
