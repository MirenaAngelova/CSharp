using Empires6.Models.EventArgs;

namespace Empires6.Models.EventHandlers
{
    public delegate void UnitProducedEventHandler(object sender, UnitProducedEventArgs e);

    public delegate void ResourceProducedEventHandler(object sender, ResourceProducedEventArgs e);
}