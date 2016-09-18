namespace Empires.Models.EventArgs
{
    using Interfaces;
    
    public class ResourceProducedEventArgs
    {
        public ResourceProducedEventArgs(IResource resource)
        {
            this.Resource = resource;
        }

        public IResource Resource { get; set; }
    }
}
