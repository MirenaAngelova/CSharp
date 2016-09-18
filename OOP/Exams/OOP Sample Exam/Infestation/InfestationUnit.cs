using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public abstract class InfestationUnit : Unit
    {
        protected InfestationUnit(
            string id, 
            UnitClassification biological, 
            int parasiteHealth, 
            int parasitePower, 
            int parasiteAggression) 
            : base(id, biological, parasiteHealth, parasitePower, parasiteAggression)
        {
        }
        protected override bool CanAttackUnit(UnitInfo unit)
        {
            if (this.Id != unit.Id &&
                this.UnitClassification == InfestationRequirements
                .RequiredClassificationToInfest(unit.UnitClassification))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            var optimalUnitToAttack = attackableUnits.OrderBy(x => x.Health).FirstOrDefault();
            return optimalUnitToAttack;
        }

        public override Interaction DecideInteraction(IEnumerable<UnitInfo> units)
        {
            IEnumerable<UnitInfo> attackableUnits = units.Where((unit) => CanAttackUnit(unit));
            UnitInfo optimalAttackableUnit = GetOptimalAttackableUnit(attackableUnits);
            if (optimalAttackableUnit.Id != null)
            {
                return new Interaction(new UnitInfo(this), optimalAttackableUnit, InteractionType.Infest);
            }
            return Interaction.PassiveInteraction;
        }
    }
}
