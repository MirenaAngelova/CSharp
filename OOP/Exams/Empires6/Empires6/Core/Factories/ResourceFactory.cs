using Empires6.Enums;
using Empires6.Interfaces;
using Empires6.Models;

namespace Empires6.Core.Factories
{
    public class ResourceFactory : IResourceFactory
    {
        public IResource CreateResource(ResourceType resourceType, int quantity)
        {
            IResource resource = new Resource(resourceType, quantity);

            return resource;
        }
    }
}