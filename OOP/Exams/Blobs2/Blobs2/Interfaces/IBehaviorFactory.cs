namespace Blobs2.Interfaces
{
    public interface IBehaviorFactory
    {
        IBehavior Create(string behaviorName);
    }
}