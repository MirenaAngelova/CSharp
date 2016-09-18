using Empires6.Interfaces;

namespace Empires6.Models.EventArgs
{
    using System;
    public class ResourceProducedEventArgs :EventArgs
    {
        public ResourceProducedEventArgs(IResource resource)
        {
            this.Resource = resource;
        }

        public IResource Resource { get; }
    }
}