namespace GameEngine.Items
{
    public class Axe : Item
    {
        private const int HealthEffectAxe = 0;
        private const int DefenseeffectAxe = 0;
        private const int AttackEffectAxe = 75;

        public Axe(string id) 
            : base(id, HealthEffectAxe, DefenseeffectAxe, AttackEffectAxe)
        {
        }
    }
}
