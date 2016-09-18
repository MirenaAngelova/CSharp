namespace ClashOfKings.Engine.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Attributes;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public ICollection<IMilitaryUnit> CreateUnits(string unitType, int count)
        {
            var militaryUnitType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(
                    type => type.CustomAttributes.Any(a => a.AttributeType == typeof (MilitaryUnitAttribute)) &&
                            type.Name == unitType);

            if (militaryUnitType == null)
            {
                throw new ArgumentNullException(nameof(militaryUnitType), "Unknown unit type.");
            }

            var units = Enumerable.Repeat(Activator.CreateInstance(militaryUnitType) as IMilitaryUnit, count);

            //return (ICollection<IMilitaryUnit>) units;
            return new List<IMilitaryUnit>(units);
        }
    }
}
