using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empires.Models.Units
{ 
    public class Archer : Unit
    {
        private const int ArcherDamage = 7;
        private const int ArcherHealth = 25;

        public Archer() : base(ArcherDamage, ArcherHealth)
        {
        }
    }
}
