namespace ClashOfKings.Contracts
{
    using Models.Armies;

    public interface IMilitaryUnit : IDestroyable, IAttack
    {
        decimal TrainingCost { get; }

        double UpkeepCost { get; }

        int HousingSpacesRequired { get; }

        UnitType Type { get; }
    }
}