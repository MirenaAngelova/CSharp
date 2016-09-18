namespace Empires.Interfaces
{
    using Models.EventHandlers;
    public interface IResourceProducer
    {
        event ResourceProducedEventHandler OnResourceProduced;
    }
}