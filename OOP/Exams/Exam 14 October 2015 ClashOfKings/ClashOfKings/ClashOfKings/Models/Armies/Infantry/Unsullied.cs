namespace ClashOfKings.Models.Armies.Infantry
{
    using Attributes;

    [MilitaryUnit]
    public class Unsullied : MilitaryUnit//1 Housing Space Required
    {
        private const int UnsulliedArmor = 5;
        private const int UnsulliedDamage = 25;
        private const decimal UnsulliedTrainingCost = 42.5m;
        private const double UnsulliedUpkeepCost = 0.75;
        private const int UnsulliedHousingSpacesRequired = 1;
        private const UnitType UnsulliedType = UnitType.Infantry;

        public Unsullied() :
            base(
                UnsulliedArmor,
                UnsulliedDamage,
                UnsulliedTrainingCost,
                UnsulliedUpkeepCost,
                UnsulliedHousingSpacesRequired, 
                UnsulliedType)
        {
        }
    }
}
