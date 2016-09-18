namespace Empires.Interfaces
{
    using System.Collections.Generic;
    using Models.Enum;

    public interface IDatabase
    {
        IEnumerable<IBuilding> Biuldings { get; }

        void AddBuilding(IBuilding building);

        IDictionary<string, int> Units { get; }

        void AddUnits(IUnit unit);

        IDictionary<TypeResource, int> Resources { get; }
    }
}