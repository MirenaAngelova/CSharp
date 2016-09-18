using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Empires6.Enums;

namespace Empires6.Interfaces
{
    public interface IDatabase
    {
        IEnumerable<IBuilding> Buildings { get; }

        void AddBuildings(IBuilding building);

        IDictionary<string, int> Units { get; }

        void AddUnits(IUnit unit);

        IDictionary<ResourceType, int> Resources { get; } 
    }
}