namespace Empires.Core
{
    using System;
    using System.Collections.Generic;

    using Interfaces;
    using Models.Enum;

    public class Database : IDatabase
    {
        private readonly ICollection<IBuilding> buildings = new List<IBuilding>();

        public Database()
        {
            this.Units = new Dictionary<string, int>();
            this.Resources = new Dictionary<TypeResource, int>();
            this.InitResource();
        }

        public IEnumerable<IBuilding> Biuldings => this.buildings;

        public IDictionary<string, int> Units { get; private set; }

        public IDictionary<TypeResource, int> Resources { get; private set; }

        private void InitResource()
        {
            var type = Enum.GetValues(typeof(TypeResource));
            foreach (TypeResource typeResource in type)
            {
                this.Resources.Add(typeResource, 0);
            }
        }


        public void AddBuilding(IBuilding building)
        {
            if (building == null)
            {
                throw new ArgumentException(nameof(building), "The building cannot be null.");
            }

            this.buildings.Add(building);
        }

       
        public void AddUnits(IUnit unit)
        {
            if (unit == null)
            {
                throw new ArgumentException(nameof(unit), "The unit cannot be null.");
            }

            var typeUnit = unit.GetType().Name;
            if (!this.Units.ContainsKey(typeUnit))
            {
                this.Units.Add(typeUnit, 0);
            }

            this.Units[typeUnit]++;
        }
    }
}
