using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public abstract class Catalysts : Supplements
    {
        protected Catalysts(int healthEffect, int powerEffect, int aggressionEffect) 
            : base(healthEffect, powerEffect, aggressionEffect)
        {
        }
    }
}
