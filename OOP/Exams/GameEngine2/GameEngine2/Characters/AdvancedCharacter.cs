using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine2.Enum;
using GameEngine2.Items;

namespace GameEngine2.Characters
{
    public abstract class AdvancedCharacter : Character
    {
        protected AdvancedCharacter(string id, int x, int y, int healthPoints, int defensePoints, Team team, int range) 
            : base(id, x, y, healthPoints, defensePoints, team, range)
        {
        }

        public override void AddToInventory(Item item)
        {
            this.ApplyItemEffects(item);
            this.Inventory.Add(item);
        }

        public override void RemoveFromInventory(Item item)
        {
            this.RemoveItemEffects(item);
            this.Inventory.Remove(item);
        }
    }
}
