using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empires6.Constants;

namespace Empires6.Models.Units
{
    public class Swordsman : Unit
    {
        public Swordsman() : base(Constant.SwordsmanHealth, Constant.SwordsmanDamage)
        {
        }
    }
}
