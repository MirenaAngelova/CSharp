using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empires.Interfaces;

namespace Empires.Models.EventArgs
{
    public class UnitProducedEventArgs 
    {
        public UnitProducedEventArgs(IUnit unit)
        {
            this.Unit = unit;
        }

        public IUnit Unit { get; private set; }
    }
}
