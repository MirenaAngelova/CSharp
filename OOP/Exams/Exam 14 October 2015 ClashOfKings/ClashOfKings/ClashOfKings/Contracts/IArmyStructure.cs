namespace ClashOfKings.Contracts
{
    using Models;
    using Models.Armies;

    public interface IArmyStructure
    {
        CityType RequiredCityType { get; }

        decimal BuildCost { get; }

        int Capacity { get; }

        UnitType UnitType { get; }
    }
}