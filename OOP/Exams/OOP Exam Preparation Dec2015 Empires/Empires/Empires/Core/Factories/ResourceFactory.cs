using System;
using System.Linq;
using System.Reflection;

namespace Empires.Core.Factories
{
    using Enums;
    using Interfaces;
    using Models;
    public class ResourceFactory:IResourceFactory
    {
        //public IResource CreateResource(ResourceType resourceType, int quantity)
        //{
        //    var resource = new Resource(resourceType, quantity);
        //    return resource;
        //}

        public IResource CreateResource(ResourceType resourceType, int quantity)
        {
            var type = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name.ToLowerInvariant().Equals(resourceType));
            if (type == null)
            {
                throw new ArgumentException("Unknown resource type.");
            }
            var resource = (IResource)Activator.CreateInstance(type, resourceType, quantity);
            return resource;
        }
    }
}
