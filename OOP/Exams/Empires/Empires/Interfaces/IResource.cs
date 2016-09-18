using Empires.Models.Enum;

namespace Empires.Interfaces
{
    public interface IResource
    {
        TypeResource TypeResource { get; }

        int Quantity { get; } 
    }
}