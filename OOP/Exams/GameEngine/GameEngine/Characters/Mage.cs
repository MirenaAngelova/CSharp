namespace GameEngine.Characters
{
    using System.Collections.Generic;
    using System.Linq;

    public class Mage : AttackableCharacter
    {
        private const int HealthPointsMage = 150;
        private const int DefensePointsMage = 50;
        private const int AttackPointsMage = 300;
        private const int Range = 5;

        public Mage(string id, int x, int y, Team team)
            : base(id, x, y, HealthPointsMage, DefensePointsMage, team, Range)
        {
            this.AttackPoints = AttackPointsMage;
        }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            return targetsList.LastOrDefault(t => t.IsAlive && t.Team != this.Team);
        }
    }
}
