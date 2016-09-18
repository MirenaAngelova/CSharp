namespace ClashOfKings.Models.ArmyStructure
{
    using Attributes;
    using Armies;

    [ArmyStructure]
    public class Barracks : ArmyStructure
    {
        private const CityType BarracksRequiredCityType = CityType.Keep;
        private const decimal BarracksBuildCost = 15000;
        private const int BarracksCapacity = 5000;
        private const UnitType BarracksUnitType = UnitType.Infantry;

        public Barracks() 
            : base(
                  BarracksRequiredCityType,
                  BarracksBuildCost,
                  BarracksCapacity,
                  BarracksUnitType)
        {
        }
    }
}
