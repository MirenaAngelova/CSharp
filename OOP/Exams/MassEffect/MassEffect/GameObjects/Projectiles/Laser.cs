using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassEffect.Interfaces;

namespace MassEffect.GameObjects.Projectiles
{
    class Laser : Projectile
    {
        public Laser(int damage) : base(damage)
        {
        }

        public override void Hit(IStarship target)
        {
            if (this.Damage > target.Shields)
            {
                target.Health = target.Health + target.Shields - this.Damage;
            }
            target.Shields -= this.Damage;
        }
    }
}
