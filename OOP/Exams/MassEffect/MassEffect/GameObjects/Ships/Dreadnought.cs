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
    class Dreadnought : Starship
    {
        public Dreadnought(string name,  StarSystem location) : base(name, 200, 300, 150, 700, location)
        {
        }

        public override IProjectile ProduceAttack()
        {
            int dmg = this.Damage + this.Shields/2;
            return new Laser(dmg);
        }

        public override void RespondToAttack(IProjectile projectile)
        {
            this.Shields += 50;
            base.RespondToAttack(projectile);
            this.Shields -= 50;
        }
    }
}
