using System;
using System.Linq;
using System.Reflection;
using Empires6.Interfaces;
using Empires6.Validations;

namespace Empires6.Core.Factories
{
    public class BuildingFactory : IBuildingFactory
    {
        public IBuilding Create(
            string buildingType, 
            IUnitFactory unitFactory,
            IResourceFactory resourceFactory)
        {
            var type = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name.ToLower() == buildingType);

            Validator.ValidateType(type, "building type");
            var building = Activator.CreateInstance(type, unitFactory, resourceFactory);

            return building as IBuilding;
        }
    }
}