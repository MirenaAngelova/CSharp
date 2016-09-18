using System.Collections;
using System.Collections.Generic;

namespace Blobs2.Interfaces
{
    public interface IBlobData
    {
        IEnumerable<IBlob> Blobs { get; }

        void AddBlob(IBlob blob);
    }
}