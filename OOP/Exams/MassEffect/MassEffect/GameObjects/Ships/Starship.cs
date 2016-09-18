using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassEffect.GameObjects.Enhancements;
using MassEffect.GameObjects.Locations;
using MassEffect.Interfaces;

namespace MassEffect.GameObjects.Ships
{
     public abstract class Starship : IStarship
    {
        private IList<Enhancement> enhancements;

        protected Starship(string name, int health, int shields, int damage,double fuel, StarSystem location)
        {
            this.Name = name;
            this.Health = health;
            this.Shields = shields;
            this.Damage = damage;
            this.Fuel = fuel;
            this.Location = location;
            this.enhancements = new List<Enhancement>();

        }

        public IEnumerable<Enhancement> Enhancements
        {
            get { return this.enhancements; }
        }
        public void AddEnhancement(Enhancement enhancement)
        {
            if (enhancement == null)
            {
                throw new ArgumentNullException("Enhancement cannot be null.");
            }
            this.enhancements.Add(enhancement);
            if (enhancement.Name == "ThanixCanon")
            {
                this.Damage += 50;
            }
            else if (enhancement.Name == "KineticBarrier")
            {
                this.Shields += 100;
            }
            else if (enhancement.Name == "ExtendedFuelCells")
            {
                this.Fuel += 200;
            }
        }

        public string Name { get; set; }
        public int Health { get; set; }
        public int Shields { get; set; }
        public int Damage { get; set; }
        public double Fuel { get; set; }
        public StarSystem Location { get; set; }
        public abstract IProjectile ProduceAttack();

        public virtual  void RespondToAttack(IProjectile projectile)
        {
            projectile.Hit(this);
        }

         public override string ToString()
         {
             StringBuilder exit = new StringBuilder();
             exit.AppendLine(string.Format("--{0} - {1}", this.Name, this.GetType().Name));
             if (this.Health <= 0)
             {
                 exit.Append("Destroyed");
             }
             else
             {
                 exit.AppendLine(string.Format("-Location: {0}", this.Location.Name));
                 exit.AppendLine(string.Format("-Health: {0}", this.Health));
                 exit.AppendLine(string.Format("-Shields: {0}", this.Shields));
                 exit.AppendLine(string.Format("-Damage: {0}", this.Damage));
                 exit.AppendLine(string.Format("-Fuel: {0}", this.Fuel));
                 if (this.enhancements.Count == 0)
                 {
                     exit.Append(string.Format("-Enhacements: {0}", "N/A"));
                 }
                 else
                 {
                     exit.Append(String.Format("-Enhancements: {0}",
                         string.Join(", ", this.enhancements.Select(enhancements => enhancements.Name))));
                 }
             }
             return exit.ToString();
         }
    }
}
