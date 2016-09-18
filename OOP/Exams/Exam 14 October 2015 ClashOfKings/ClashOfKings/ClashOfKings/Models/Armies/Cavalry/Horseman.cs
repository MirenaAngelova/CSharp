namespace ClashOfKings.Models.Armies.Cavalry
{
    using Attributes;

    [MilitaryUnit]
    public class Horseman : MilitaryUnit
    {
        private const int HorsemanArmor = 10;
        private const int HorsemanDamage = 20;
        private const decimal HorsemanTrainingCost = 20;
        private const double HorsemanUpkeepCost = 2;
        private const int HorsemanHousingSpacesRequired = 2;
        private const UnitType HorsemanType = UnitType.Cavalry;

        public Horseman()
            : base(
                  HorsemanArmor,
                  HorsemanDamage,
                  HorsemanTrainingCost,
                  HorsemanUpkeepCost,
                  HorsemanHousingSpacesRequired,
                  HorsemanType)
        {
        }
    }
}
