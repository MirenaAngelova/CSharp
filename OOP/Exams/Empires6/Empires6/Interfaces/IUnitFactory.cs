namespace Empires6.Interfaces
{
    public interface IUnitFactory
    {
        IUnit CreateUnit(string unitType);
    }
}