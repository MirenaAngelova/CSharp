﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class AggressionCatalyst : Catalysts
    {
        private const int AggressionCatalystEffect = 3;
        public AggressionCatalyst(
            )
            : base(0, 0, AggressionCatalystEffect)
        {
        }
    }
}
