using System;

namespace Empires.Models
{
    using Empires.Interfaces;
    public abstract class Unit : IUnit
    {
        private int attackDamage;
        private int health;

        protected Unit(int attackDamage, int health)
        {
            this.AttackDamage = attackDamage;
            this.InitHealt(health);
        }

        private void InitHealt(int initialHealth)
        {
            if (initialHealth <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    "initialHealth", 
                    "Units should have positive health at the time of their creation");
            }
            this.health = initialHealth;
        }

        public int AttackDamage
        {
            get { return this.attackDamage; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("attack damage", "Units should have non-negative damage.");
                }
                this.attackDamage = value;
            }
        }

        public int Health
        {
            get
            {
                return this.health;
            }
            set { this.health = value < 0 ? 0 : value; }
        }
    }
}
