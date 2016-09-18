using Empires6.Enums;

namespace Empires6.Interfaces
{
    public interface IResourceFactory
    {
        IResource CreateResource(ResourceType resourceType, int quantity);
    }
}