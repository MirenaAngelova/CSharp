using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class HealthCatalyst : Catalysts
    {
        private const int HealthCatalystEffect = 3;
        public HealthCatalyst() : base(HealthCatalystEffect, 0, 0)
        {
        }
    }
}
