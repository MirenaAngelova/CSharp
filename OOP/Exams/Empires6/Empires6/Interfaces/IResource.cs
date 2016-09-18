using Empires6.Enums;

namespace Empires6.Interfaces
{
    public interface IResource
    {
        ResourceType ResourceType { get; set; } 

        int Quantity { get; }
    }
}