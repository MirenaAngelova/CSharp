namespace Empires.Interfaces
{
    using Models.EventHandlers;
    public interface IUnitProducer
    {
        event UnitProducedEventHandler OnUnitProduced;
    }
}