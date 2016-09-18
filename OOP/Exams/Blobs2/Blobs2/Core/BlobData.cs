namespace Blobs2.Core
{
    using System.Collections.Generic;

    using Interfaces;

    public class BlobData : IBlobData
    {
        private readonly ICollection<IBlob> blobs;

        public BlobData(ICollection<IBlob> blobs)
        {
            this.blobs = blobs;
        }

        public IEnumerable<IBlob> Blobs => this.blobs;

        public void AddBlob(IBlob blob)
        {
            this.blobs.Add(blob);
        }
    }
}