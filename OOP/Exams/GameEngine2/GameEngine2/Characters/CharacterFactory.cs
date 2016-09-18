using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine2.Enum;

namespace GameEngine2.Characters
{
    public static class CharacterFactory
    {
        public static Character Create(string type, string id, Team team, int x, int y)
        {
            switch (type.ToLower())
            {
                case "warrior":
                    return new Warrior(id, x, y, team);
                case "mage":
                    return new Mage(id, x, y, team);
                case "Healer":
                    return new Healer(id, x, y, team);
                default:
                    throw new ArgumentException("Invalid character type.");
            }
        }
    }
}
