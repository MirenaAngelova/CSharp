namespace Empires.Models.EventHandlers
{
    using EventArgs;
    public delegate void UnitProducedEventHandler(object sender, UnitProducedEventArgs e);

    public delegate void ResourceProducedEventHandler(object sender, ResourceProducedEventArgs e);
}
