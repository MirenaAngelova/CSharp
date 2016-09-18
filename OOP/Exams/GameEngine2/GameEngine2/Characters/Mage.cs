using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine2.Constants;
using GameEngine2.Enum;

namespace GameEngine2.Characters
{
    public class Mage : AttackableCharacter
    {
        public Mage(string id, int x, int y, Team team) 
            : base(
                  id, 
                  x,
                  y, 
                  CharactersConstants.MageHealthPoints, 
                  CharactersConstants.MageDefensePoints, 
                  team, 
                  CharactersConstants.MageRange)
        {
            this.AttackPoints = CharactersConstants.MageAttackPoints;
        }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            return targetsList.LastOrDefault(t => t.IsAlive && t.Team != this.Team);
        }
    }
}
