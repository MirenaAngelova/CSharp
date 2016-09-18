namespace ClashOfKings.Models.Armies.Infantry
{
    using Attributes;

    [MilitaryUnit]
    public class SellSword : MilitaryUnit
    {
        private const int SellSwordArmor = 5;
        private const int SellSwordDamage = 15;
        private const decimal SellSwordTrainingCost = 20;
        private const double SellSwordUpkeepCost = 1;
        private const int SellSwordHousingSpacesRequired = 1;
        private const UnitType SellSwordArmyType = UnitType.Infantry;

        public SellSword()
            : base(
                  SellSwordArmor,
                  SellSwordDamage,
                  SellSwordTrainingCost,
                  SellSwordUpkeepCost,
                  SellSwordHousingSpacesRequired,
                  SellSwordArmyType)
        {
        }
    }
}
