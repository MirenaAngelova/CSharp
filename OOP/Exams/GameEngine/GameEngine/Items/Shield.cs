namespace GameEngine.Items
{
    public class Shield : Item
    {
        private const int HealthEffectShield = 0;
        private const int DefenseEffectShield = 50;
        private const int AttackEffectShield = 0;

        public Shield(string id) 
            : base(id, HealthEffectShield, DefenseEffectShield, AttackEffectShield)
        {
        }
    }
}
