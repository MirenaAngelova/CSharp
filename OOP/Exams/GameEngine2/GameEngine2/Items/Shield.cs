using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine2.Constants;

namespace GameEngine2.Items
{
    public class Shield : Item
    {
        public Shield(string id)
            : base(
                  id, 
                  ItemsConstants.ShieldHealthEffect,
                  ItemsConstants.ShieldDefenseEffect, 
                  ItemsConstants.ShieldAttackEffect)
        {
        }
    }
}
