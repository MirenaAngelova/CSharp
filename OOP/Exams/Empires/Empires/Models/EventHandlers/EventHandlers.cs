using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using Empires.Models.EventArgs;

namespace Empires.Models.EventHandlers
{
    public delegate void UnitProducedEventHandler(object sender, UnitProducedEventArgs e);

    public delegate void ResourceProducedEventHandler(object sender, ResourceProducedEventArgs e);
}
