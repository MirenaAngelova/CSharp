using System;
using System.Collections.Generic;
using Empires6.Enums;
using Empires6.Interfaces;
using Empires6.Validations;

namespace Empires6.Core
{
    public class Database : IDatabase
    {
        private readonly ICollection<IBuilding> buildings = new List<IBuilding>(); 
       
        public Database()
        { 
            this.Units= new Dictionary<string, int>();
            this.Resources = new Dictionary<ResourceType, int>();
            this.InitResource();
        }

        private void InitResource()
        {
            var type = Enum.GetValues(typeof (ResourceType));
            foreach (ResourceType resource in type)
            {
                this.Resources.Add(resource, 0);
            }
        }

        public IEnumerable<IBuilding> Buildings => this.buildings;
        public void AddBuildings(IBuilding building)
        {
            Validator.ValidateTypes(building, "building");
            this.buildings.Add(building);
        }

        public IDictionary<string, int> Units { get; }

        public void AddUnits(IUnit unit)
        {
           Validator.ValidateTypes(unit, "unit");
            var typeUnit = unit.GetType().Name;
            if (!this.Units.ContainsKey(typeUnit))
            {
                this.Units.Add(typeUnit, 0);
            }

            this.Units[typeUnit]++;
        }

        public IDictionary<ResourceType, int> Resources { get; }
    }
}