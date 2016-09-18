namespace Blobs2.Models.Attacks
{
    using Interfaces;

    public class PutridFart : BaseAttack
    {
        public override void ExecuteAttack(IBlob target, int damage)
        {
            target.Respond(damage);
        }

        public override void ExecuteEffectsOnAttacker(IBlob attacker)
        {
        }
    }
}
