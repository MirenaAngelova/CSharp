using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine2.Constants;

namespace GameEngine2.Items
{
    public class Axe : Item
    {
        public Axe(string id) 
            : base(id, ItemsConstants.AxeHealthEffect, ItemsConstants.AxeDefenseEffect, ItemsConstants.AxeAttackEffect)
        {
        }
    }
}
