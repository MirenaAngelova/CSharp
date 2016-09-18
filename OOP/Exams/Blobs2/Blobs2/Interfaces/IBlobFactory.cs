﻿namespace Blobs2.Interfaces
{
    public interface IBlobFactory
    {
        IBlob Create(string name, int health, int damage, IBehavior behavior, IAttack attack);
    }
}