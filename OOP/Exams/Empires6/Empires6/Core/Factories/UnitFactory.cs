using System;
using System.Linq;
using System.Reflection;
using Empires6.Constants;
using Empires6.Interfaces;
using Empires6.Validations;

namespace Empires6.Core.Factories
{
    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            var type = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == unitType);

           Validator.ValidateType(type, "unit type");

            var unit = Activator.CreateInstance(type);

            return unit as IUnit;
        }
    }
}