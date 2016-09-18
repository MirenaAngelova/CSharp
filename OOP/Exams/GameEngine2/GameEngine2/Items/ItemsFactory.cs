using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine2.Items
{
    public static class ItemsFactory
    {
        public static Item Create(string itemType, string id)
        {
            switch (itemType.ToLower())
            {
                case "axe":
                    return new Axe(id);
                case "injection":
                    return new Injection(id);
                case "pill":
                    return new Pill(id);
                case "shield":
                    return new Shield(id);
                default:
                    throw new ArgumentException("Invalid item type.");
            }
        }
    }
}
