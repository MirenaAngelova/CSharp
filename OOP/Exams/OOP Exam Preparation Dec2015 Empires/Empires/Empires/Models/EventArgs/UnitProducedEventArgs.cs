namespace Empires.Models.EventArgs
{
    using Interfaces;
    public class UnitProducedEventArgs
    {
        public UnitProducedEventArgs(IUnit unit)
        {
            this.Unit = unit;
        }

        public IUnit Unit { get; set; }
    }
}
