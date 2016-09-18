using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class Queen : InfestationUnit
    {
        private const int QueenHealth = 30;
        private const int QueenPower = 1;
        private const int QueenAggression = 1;
        public Queen(string id) : base(id, UnitClassification.Psionic, QueenHealth, QueenPower, QueenAggression)
        {
        }
    }
}
