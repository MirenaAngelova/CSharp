namespace Blobs2.Interfaces
{
    public interface IAttackFactory
    {
        IAttack Create(string attackName);
    }
}