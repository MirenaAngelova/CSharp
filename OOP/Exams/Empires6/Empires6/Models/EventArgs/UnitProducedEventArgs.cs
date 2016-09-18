using Empires6.Interfaces;

namespace Empires6.Models.EventArgs
{
    using System;
    public class UnitProducedEventArgs : EventArgs
    {
        public UnitProducedEventArgs(IUnit unit)
        {
            this.Unit = unit;
        }

        public IUnit Unit { get; }
    }
}