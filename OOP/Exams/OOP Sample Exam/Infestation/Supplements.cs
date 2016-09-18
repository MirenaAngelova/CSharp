using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    abstract public class Supplements : ISupplement
    {
        protected Supplements(int healthEffect, int powerEffect, int aggressionEffect)
        {
            this.HealthEffect = healthEffect;
            this.PowerEffect = powerEffect;
            this.AggressionEffect = aggressionEffect;
        }
        public virtual void ReactTo(ISupplement otherSupplement)
        {
        }

        public virtual int PowerEffect { get; protected set; }
        public virtual int HealthEffect { get; protected set; }
        public virtual int AggressionEffect { get; protected set; }
    }
}
