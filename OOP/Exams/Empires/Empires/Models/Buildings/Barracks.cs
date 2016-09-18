using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empires.Interfaces;
using Empires.Models.Enum;

namespace Empires.Models.Buildings
{
    public class Barracks : Building
    {
        private const string SwordsmanTypeUnit = "Swordsman";
        private const int SwordsmanUnitTurns = 4;
        private const TypeResource SwordsmanTypeResource = TypeResource.Steel;
        private const int SwordsmanResourceTurns = 3;
        private const int SwordsmanQuantity = 10;

        public Barracks(IUnitFactory unitFactory, IResourceFactory resourceFactory) 
            : base(
                  SwordsmanTypeUnit, 
                  SwordsmanUnitTurns, 
                  SwordsmanTypeResource, 
                  SwordsmanResourceTurns, 
                  SwordsmanQuantity, 
                  unitFactory, 
                  resourceFactory)
        {
        }
    }
}
