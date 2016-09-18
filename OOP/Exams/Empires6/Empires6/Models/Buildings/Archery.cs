using Empires6.Constants;
using Empires6.Interfaces;

namespace Empires6.Models.Buildings
{
    public class Archery : Building
    {
        public Archery(IUnitFactory unitFactory, IResourceFactory resourceFactory) 
            : base(Constant.ArcheryUnit,
                  Constant.ArcheryUnitTurns, 
                  Constant.ArcheryResourceType, 
                  Constant.ArcheryQuantity,
                  Constant.ArcheryResourceTurns,
                  unitFactory, 
                  resourceFactory)
        {
        }
    }
}