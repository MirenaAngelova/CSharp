using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Empires.Models.Units
{
    public class Swordsman : Unit
    {
        private const int SwordsmanDamage = 13;
        private const int SwordsmanHealth = 40;

        public Swordsman() : base(SwordsmanDamage, SwordsmanHealth)
        {
        }
    }
}
