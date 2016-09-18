
using Empires.Enums;
using Empires.Interfaces;

namespace Empires.Models
{
    public class Barracks : Building
    {
        private const string BarracksUnitType = "Swordsman";
        private const int BarracksUnitCicleLength = 4;
        private const ResourceType BarracksResourceType = ResourceType.Steel;
        private const int BarrackResourceCicleLength = 3;
        private const int BarrackResourceQuantity = 10;


        public Barracks(IUnitFactory unitFactory, IResourceFactory resourceFactory) 
            : base(
            BarracksUnitType, 
            BarracksUnitCicleLength, 
            BarracksResourceType, 
            BarrackResourceCicleLength, 
            BarrackResourceQuantity, 
            unitFactory, 
            resourceFactory)
        {
        }
    }
}
