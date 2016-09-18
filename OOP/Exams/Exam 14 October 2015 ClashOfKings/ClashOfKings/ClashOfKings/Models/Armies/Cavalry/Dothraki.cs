namespace ClashOfKings.Models.Armies.Cavalry
{
    using Attributes;

    [MilitaryUnit]
    public class Dothraki : MilitaryUnit
    {
        private const int DohtrakiArmor = 5;
        private const int DothrakiDamage = 25;
        private const decimal DothrakiTrainingCost = 25;
        private const double DothrakiUpkeepCost = 1.8;
        private const int DothrakiHousingSpacesRequired = 2;
        private const UnitType DothrakiType = UnitType.Cavalry;

        public Dothraki() 
            : base(
                  DohtrakiArmor, 
                  DothrakiDamage, 
                  DothrakiTrainingCost, 
                  DothrakiUpkeepCost,
                  DothrakiHousingSpacesRequired, 
                  DothrakiType)
        {
        }
    }
}
