namespace GameEngine.Characters
{
    using System.Collections.Generic;
    using System.Linq;

    using Interfaces;

    public class Healer : AdvancedCharacter, IHeal
    {
        private const int HealthPointsHealer = 75;
        private const int DefensePointsHealer = 50;
        private const int HealingPointsHealer = 60;
        private const int RangeHealer = 6;

        public Healer(string id, int x, int y, Team team)
            : base(id, x, y, HealthPointsHealer, DefensePointsHealer, team, RangeHealer)
        {
            this.HealingPoints = HealingPointsHealer;
        }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            return targetsList
                .Where(t => t.Id != this.Id)
                .Where(t => t.Team == t.Team)
                .Where(t => t.IsAlive)
                .OrderBy(t => t.HealthPoints)
                .FirstOrDefault();
        }

        public int HealingPoints { get; set; }

        public override string ToString()
        {
            return base.ToString() + ", Healing: " + this.HealingPoints;
        }
    }
}
