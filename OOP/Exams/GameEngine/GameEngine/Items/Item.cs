namespace GameEngine.Items
{
    public abstract class Item : GameObject
    {
        protected Item(string id, int healthEffect, int defenseEffect, int attackEffect) : base(id)
        {
            this.HealthEffect = healthEffect;
            this.DefenseEffect = defenseEffect;
            this.AttackEffect = attackEffect;
        }

        public int AttackEffect { get; set; }

        public int DefenseEffect { get; set; }

        public int HealthEffect { get; set; }
    }
}
