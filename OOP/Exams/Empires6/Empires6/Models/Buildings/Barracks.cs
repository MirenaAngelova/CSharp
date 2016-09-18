using Empires6.Constants;
using Empires6.Enums;
using Empires6.Interfaces;
using Empires6.Models.EventHandlers;

namespace Empires6.Models.Buildings
{
    public class Barracks : Building
    {
        public Barracks(IUnitFactory unitFactory, IResourceFactory resourceFactory) 
            : base(Constant.BarracksUnit,
                  Constant.BarracksUnitTurns, 
                  Constant.BarracksResourceType, 
                  Constant.BarracksQuantity,
                  Constant.BarracksResourceTurns,
                 unitFactory, 
                 resourceFactory)
        {
        }
    }
}