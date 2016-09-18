namespace ClashOfKings.Models.Armies.Cavalry
{
    using Attributes;
    
    [MilitaryUnit]
    public class Knight : MilitaryUnit
    {
        private const int KnightArmor = 30;
        private const int KnightDamage = 35;
        private const decimal KnightTrainingCost = 50;
        private const double KnightUpkeepCost = 3.5;
        private const int KnightHousingSpacesRequired = 3;
        private const UnitType KnightType = UnitType.Cavalry;

        public Knight()
            : base(
                  KnightArmor,
                  KnightDamage,
                  KnightTrainingCost,
                  KnightUpkeepCost,
                  KnightHousingSpacesRequired,
                  KnightType)
        {
        }
    }
}
