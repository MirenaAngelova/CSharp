namespace Academy_RPG.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using AcademyRPG;
    public class Giant : Fighter, IFighter, IControllable, IWorldObject, IGatherer
    {
        private bool hasStone;
        public Giant(string name, Point position)
            : base(name, position, 0, 150, 80, 200)
        {
            this.hasStone = false;
        }

        public override int GetTargetIndex(List<WorldObject> availableTargets)
        {
            var target = availableTargets.FirstOrDefault(x => x.Owner != 0);
            return availableTargets.IndexOf(target);
        }

        public bool TryGather(IResource resource)
        {
            bool canGather = false;
            if (resource.Type == ResourceType.Stone)
            {
                canGather = true;
                if (!hasStone)
                {
                    base.AttackPoints += 100;
                    this.hasStone = true;
                }
            }
            return canGather;
        }
    }
}
