using System;
using System.Linq;
using System.Reflection;
using Empires.Models;

namespace Empires.Core.Factories
{
    using Interfaces;
    public class BuildingFactory : IBuildingFactory
    {

        //public IBuilding CreateBuilding(
        //    string buildingType, 
        //    IUnitFactory unitFactory, 
        //    IResourceFactory resourceFactory)
        //{
        //    switch (buildingType)
        //    {
        //        case"Archery":
        //            return new Archery(unitFactory, resourceFactory);
        //        case "Barracks":
        //            return new Barracks(unitFactory, resourceFactory);
        //        default:
        //            throw new ArgumentException("Unknown building type.");
        //    }
        //}

        public IBuilding CreateBuilding(
            string buildingType,
            IUnitFactory unitFactory,
            IResourceFactory resourceFactory)
        {
            var type = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name.ToLowerInvariant() == buildingType);
            if (type == null)
            {
                throw new ArgumentException("Unknown building type.");
            }
            var building = (IBuilding)Activator.CreateInstance(type, unitFactory, resourceFactory);
            return building;
        }
    }
}
