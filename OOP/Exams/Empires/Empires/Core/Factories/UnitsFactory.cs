namespace Empires.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Interfaces;

    public class UnitsFactory : IUnitFactory
    {
        public IUnit CreateUnit(string typeUnit)
        {
            var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == typeUnit);

            if (type == null)
            {
                throw new ArgumentException(nameof(type),
                    "Cannot found this type of unit in Assembly.");
            }

            var unit = (IUnit) Activator.CreateInstance(type);
            return unit;
        }
    }
}
