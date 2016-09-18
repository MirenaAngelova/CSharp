using Empires.Models.EventHandlers;

namespace Empires.Interfaces
{
    public interface IUnitProducer
    {
        event UnitProducedEventHandler OnUnitProduced; 
    }
}