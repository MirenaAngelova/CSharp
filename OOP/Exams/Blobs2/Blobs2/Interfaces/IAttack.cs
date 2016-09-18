﻿namespace Blobs2.Interfaces
{
    public interface IAttack
    {
        void ExecuteAttack(IBlob target, int damage);

        void ExecuteEffectsOnAttacker(IBlob attacker);
    }
}