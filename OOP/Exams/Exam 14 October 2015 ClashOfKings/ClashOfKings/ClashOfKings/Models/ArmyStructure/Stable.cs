namespace ClashOfKings.Models.ArmyStructure
{
    using Attributes;
    using Armies;

    [ArmyStructure]
    public class Stable : ArmyStructure
    {
        private const CityType StableRequiredCityType = CityType.FortifiedCity;
        private const decimal StableBuildCost = 75000;
        private const int StableCapacity = 2500;
        private const UnitType StableUnitType = UnitType.Cavalry;

        public Stable() : base(StableRequiredCityType, StableBuildCost, StableCapacity, StableUnitType)
        {
        }
    }
}
