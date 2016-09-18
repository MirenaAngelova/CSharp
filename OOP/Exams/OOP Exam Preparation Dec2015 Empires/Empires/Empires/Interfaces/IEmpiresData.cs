using System.Collections.Generic;

namespace Empires.Interfaces
{
    using Empires.Enums;
    public interface IEmpiresData
    {
        IEnumerable<IBuilding> Buildings { get; }
        void AddBuilding(IBuilding building);
        IDictionary<string, int> Units { get; }
        void AddUnit(IUnit unit);
        IDictionary<ResourceType, int> Resources { get; } 
    }
}