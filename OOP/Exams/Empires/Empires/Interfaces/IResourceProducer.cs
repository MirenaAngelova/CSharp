using Empires.Models.EventHandlers;

namespace Empires.Interfaces
{
    public interface IResourceProducer
    {
        event ResourceProducedEventHandler OnResourceProduced; 
    }
}