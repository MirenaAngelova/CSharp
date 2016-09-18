using Empires.Models.Enum;

namespace Empires.Interfaces
{
    public interface IResourceFactory
    {
        IResource CreateResource(TypeResource typeResource, int quantity);
    }
}