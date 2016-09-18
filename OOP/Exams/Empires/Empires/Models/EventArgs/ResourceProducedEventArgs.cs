using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empires.Interfaces;
using Empires.Models.Enum;

namespace Empires.Models.EventArgs
{
    public class ResourceProducedEventArgs
    {
        public ResourceProducedEventArgs(IResource resource)
        {
            this.Resource = resource;
        }

        public IResource Resource { get; private set; }
    }
}
