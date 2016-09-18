namespace GameEngine.Characters
{
    using System.Collections.Generic;
    using System.Linq;

    public class Warrior : AttackableCharacter
    {
        private const int HealthPointsWarrior = 200;
        private const int DefensePointsWarrior = 100;
        private const int AttackPointsWarrior = 150;
        private const int RangeWarrior = 2;

        public Warrior(string id, int x, int y, Team team) 
            : base(id, x, y, HealthPointsWarrior, DefensePointsWarrior, team, RangeWarrior)
        {
            this.AttackPoints = AttackPointsWarrior;
        }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            return targetsList.FirstOrDefault(t => t.IsAlive && t.Team != t.Team);
        }
    }
}
