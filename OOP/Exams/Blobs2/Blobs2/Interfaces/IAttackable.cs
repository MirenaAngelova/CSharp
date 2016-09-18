using Blobs2.Models.EventHandlers;

namespace Blobs2.Interfaces
{
    public interface IAttackable
    {
        void Respond(int damage);

        event BlobDeadEventHandler OnBlobDead;
    }
}