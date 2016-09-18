namespace ClashOfKings.Contracts
{
    using Models;

    public interface ICity : IUpgradeable, IDowngradeable, IDefendable, ITaxable, IArmyBase, IUpdateable, IRenderable
    {
        string Name { get; }

        CityType CityType { get; }

        IHouse ControllingHouse { get; set; }
    }
}