namespace Blobs2.Models.EventHandlers
{
    using Events;

    public delegate void BehaviorToggledEventHandler(object sender, BehaviorToggledEventArgs e);

    public delegate void BlobDeadEventHandler(object sender, BlobDeadEventArgs e);
}
