namespace Empires.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Interfaces;

    public class BuildingsFactory : IBuildingFactory
    {
        public IBuilding CreateBuilding(
            string typeBuilding, IUnitFactory unitFactory, IResourceFactory resourceFactory)
        {
            var type = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name.ToLower() == typeBuilding);
            if (type == null)
            {
                throw new ArgumentException(nameof(type),
                    "Cannot found this type of building in Assembly.");
            }

            var building = (IBuilding) Activator.CreateInstance(type, unitFactory, resourceFactory);
            return building;
        }
    }
}