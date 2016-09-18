namespace ClashOfKings.Models.ArmyStructure
{
    using Attributes;
    using Armies;

    [ArmyStructure]
    public class DragonLair : ArmyStructure
    {
        private const CityType DragonLairRequiredCityType = CityType.Capital;
        private const decimal DragonLairBuildCost = 200000;
        private const int DragonLairCapacity = 3;
        private const UnitType DragonLairUnitType = UnitType.AirForce;

        public DragonLair() 
            : base(
                  DragonLairRequiredCityType,
                  DragonLairBuildCost,
                  DragonLairCapacity,
                  DragonLairUnitType)
        {
        }
    }
}
