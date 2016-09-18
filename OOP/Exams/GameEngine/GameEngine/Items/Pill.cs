namespace GameEngine.Items
{
    public class Pill : Bonus
    {
        private const int HealthEffectPill = 0;
        private const int DefenseEffectPill = 0;
        private const int AttackeffectPill = 100;
        private const int TimeOutTurns = 1;

        public Pill(string id) 
            : base(id, HealthEffectPill, DefenseEffectPill, AttackeffectPill)
        {
            this.Timeout = TimeOutTurns;
            this.Countdown = TimeOutTurns;
        }
    }
}
