using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine2.Constants;
using GameEngine2.Enum;
using GameEngine2.Interfaces;
using GameEngine2.Items;

namespace GameEngine2.Characters
{
    public class Warrior : AttackableCharacter
    {
        public Warrior(string id, int x, int y, Team team) 
            : base(
                  id, 
                  x, 
                  y, 
                  CharactersConstants.WarriorHealthPoints, 
                  CharactersConstants.WarriorDefensePoints, 
                  team, 
                  CharactersConstants.WarriorRange)
        {
            this.AttackPoints = CharactersConstants.WarriorAttackPoints;
        }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            return targetsList.FirstOrDefault(t => t.IsAlive && t.Team != this.Team);
        }
    }
}
