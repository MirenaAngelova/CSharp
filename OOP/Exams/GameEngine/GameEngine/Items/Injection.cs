namespace GameEngine.Items
{
    public class Injection : Bonus
    {
        private const int HealthEffectInjection = 200;
        private const int DefenseEffectInjection = 0;
        private const int AttackEffectInjection = 0;
        private const int TimeOutTurns = 3;

        public Injection(string id) 
            : base(id, HealthEffectInjection, DefenseEffectInjection, AttackEffectInjection)
        {
            this.Timeout = TimeOutTurns;
            this.Countdown = TimeOutTurns;
        }
    }
}
