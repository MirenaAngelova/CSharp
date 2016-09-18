using System;
using Empires6.Constants;
using Empires6.Interfaces;
using Empires6.Validations;

namespace Empires6.Models.Units
{
    public abstract class Unit :IUnit
    {
        private int damage;
        private int health;
        
        protected Unit(int health, int damage)
        {
            //this.Health = health;
            this.Damage = damage;

            this.InitialHealth(health);
        }

        protected void InitialHealth(int initialHealth)
        {
           Validator.ValidatePropertyHealth(initialHealth, "positive", "health");
            this.Health = initialHealth;
        }

        public int Health
        {
            get
            {
                return this.health;
            }

            set
            {
                this.health = value < 0 ? 0 : value;
            }
        }

        public int Damage
        {
            get
            {
                return this.damage;
            }

            set
            {
                Validator.ValidatePropertyDamage(value, "non-negative", "damage");
                this.damage = value;
            }
        }
    }
}