using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class Parasite : InfestationUnit
    {
        private const int ParasiteHealth = 1;
        private const int ParasitePower = 1;
        private const int ParasiteAggression = 1;
        public Parasite(string id) 
            : base(id, UnitClassification.Biological, ParasiteHealth, ParasitePower, ParasiteAggression)
        {
        }
    }
}
