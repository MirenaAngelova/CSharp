using System.Collections.Generic;
using GameEngine2.Enum;
using GameEngine2.Items;

namespace GameEngine2.Characters
{
    public abstract class Character : GameObject
    {
        protected Character(string id, int x, int y, int healthPoints, int defensePoints, Team team, int range)
            : base(id)
        {
            this.X = x;
            this.Y = y;
            this.HealthPoints = healthPoints;
            this.DefensePoints = defensePoints;
            this.Team = team;
            this.Range = range;
            this.IsAlive = true;
            this.Inventory = new List<Item>();
        }

        public int X { get; set; }

        public int Y { get; set; }

        public int HealthPoints { get; set; }

        public int DefensePoints { get; set; }

        public Team Team { get; set; }

        public int Range { get; set; }

        public bool IsAlive { get; set; }

        public List<Item> Inventory { get; private set; }

        public abstract Character GetTarget(IEnumerable<Character> targetsList);

        public abstract void AddToInventory(Item item);

        public abstract void RemoveFromInventory(Item item);

        protected virtual void ApplyItemEffects(Item item)
        {
            this.HealthPoints += item.HealthEffect;
            this.DefensePoints += item.DefenseEffect;
        }

        protected virtual void RemoveItemEffects(Item item)
        {
            this.HealthPoints -= item.HealthEffect;
            this.DefensePoints -= item.DefenseEffect;
            if (this.HealthPoints < 0)
            {
                this.HealthPoints = 1;
            }
        }

        public override string ToString()
        {
            return $"-- Name: {this.Id}, Team: {this.Team}, Health: {this.HealthPoints}, Defense: {this.DefensePoints}";
        }
    }
}
