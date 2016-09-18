using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine2.Constants;
using GameEngine2.Enum;
using GameEngine2.Interfaces;

namespace GameEngine2.Characters
{
    public class Healer : AdvancedCharacter, IHeal
    {
        public Healer(string id, int x, int y, Team team) 
            : base(id, x, y, CharactersConstants.HealerHealthPoints, CharactersConstants.HealerDefensePoints, team, CharactersConstants.HealerRange)
        {
            this.HealingPoints = CharactersConstants.HealerHealingPoints;
        }

        public int HealingPoints { get; set; }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            return targetsList
                .Where(t => t.Id != this.Id)
                .Where(t => t.Team == this.Team)
                .Where(t => t.IsAlive)
                .OrderBy(t => t.HealthPoints)
                .FirstOrDefault();
        }
    }
}
