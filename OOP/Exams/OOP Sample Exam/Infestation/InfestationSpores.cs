using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class InfestationSpores : EffectableSupplement
    {
        private const int InfestationSporesHealth = 0;
        private const int InfestationSporesPower = -1;
        private const int InfestationSporesAggression = 20;

        public InfestationSpores()
            : base(InfestationSporesHealth, InfestationSporesPower, InfestationSporesAggression)
        {
            this.hasEffect = true;
        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement is InfestationSpores)
            {
                this.hasEffect = false;
            }
        }
    }
}
