namespace Empires.Models
{
    using Empires.Enums;
    using Empires.Interfaces;
    public class Archery : Building
    {
        private const string ArcheryUnitType = "Archer";
        private const int ArcheryUnitCicleLength = 3;
        private const ResourceType ArcheryResourceType = ResourceType.Gold;
        private const int ArcheryResourceCicleLength = 2;
        private const int ArcheryResourceQuantity = 5;
        public Archery(IUnitFactory unitFactory, IResourceFactory resourceFactory) 
            : base(
            ArcheryUnitType,
            ArcheryUnitCicleLength, 
            ArcheryResourceType, 
            ArcheryResourceCicleLength, 
            ArcheryResourceQuantity, 
            unitFactory, 
            resourceFactory)
        {
        }
    }
}
