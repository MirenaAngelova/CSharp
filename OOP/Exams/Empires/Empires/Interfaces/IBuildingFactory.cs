namespace Empires.Interfaces
{
    public interface IBuildingFactory
    {
        IBuilding CreateBuilding(string typeBuilding, IUnitFactory unitFactory, IResourceFactory resourceFactory);
    }
}