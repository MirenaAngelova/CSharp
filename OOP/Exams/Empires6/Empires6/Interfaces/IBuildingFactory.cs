namespace Empires6.Interfaces
{
    public interface IBuildingFactory
    {
        IBuilding Create(string buildingType, IUnitFactory unitFactory, IResourceFactory resourceFactory);
    }
}