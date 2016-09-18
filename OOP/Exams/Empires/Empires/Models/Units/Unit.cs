using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empires.Interfaces;

namespace Empires.Models.Units
{
    public abstract class Unit : IUnit
    {
        private int damage;
        private int health;

        protected Unit(int damage, int health)
        {
            this.Damage = damage;
            this.InitHealth(health);
        }

        private void InitHealth(int initHealth)
        {
            if (initHealth <= 0)
            {
                throw new ArgumentException(nameof(health),
                    "Units should have positive health at the time of their creation");
            }

            this.health = initHealth;
        }


        public int Damage
        {
            get
            {
                return this.damage;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                        "Units should have non-negative damage at the time of their creation");
                }

                this.health = value;//this.damage = value;
            }
        }

        public int Health
        {
            get
            {
                return this.health;
            }

            private set { this.health = value < 0 ? 0 : value; }
        }
    }
}
