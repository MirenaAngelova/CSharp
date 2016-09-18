using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empires.Interfaces;
using Empires.Models.Enum;

namespace Empires.Models.Buildings
{
    public class Archery : Building
    {
        private const string ArcheryTypeUnit = "Archer";
        private const int ArceryUnitTurns = 3;
        private const TypeResource ArcheryTypeResource = TypeResource.Gold;
        private const int ArcheryResourceTurns = 2;
        private const int ArcheryQuantity = 5;

        public Archery(
            IUnitFactory unitFactory, 
            IResourceFactory resourceFactory) 
            : base(
                  ArcheryTypeUnit,
                  ArceryUnitTurns, 
                  ArcheryTypeResource, 
                  ArcheryResourceTurns, 
                  ArcheryQuantity, 
                  unitFactory, 
                  resourceFactory)
        {
        }
    }
}
