using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassEffect.GameObjects.Locations;
using MassEffect.GameObjects.Projectiles;
using MassEffect.Interfaces;

namespace MassEffect.GameObjects.Ships
{
    class Frigate : Starship
    {
        private int projectilesFired;
        public Frigate(string name, StarSystem location) : base(name, 60, 50, 30, 220, location)
        {
        }
        public override string ToString()
        {
            string exit = base.ToString();
            if (this.Health > 0)
            {
                exit += string.Format("\n-Projectiles fired: {0}", this.projectilesFired);
            }
            return exit;
        }

        public override IProjectile ProduceAttack()
        {
            this.projectilesFired++;
            return new ShieldReaver(this.Damage);
        }

    }
}
