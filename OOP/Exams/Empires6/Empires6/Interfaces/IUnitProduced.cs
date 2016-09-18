using Empires6.Models.EventArgs;
using Empires6.Models.EventHandlers;

namespace Empires6.Interfaces
{
    public interface IUnitProduced
    {
        event UnitProducedEventHandler OnUnitProduced;
    }
}