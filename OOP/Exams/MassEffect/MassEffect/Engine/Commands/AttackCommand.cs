namespace MassEffect.Engine.Commands
{
    using MassEffect.Interfaces;
    using System;
    using System.Linq;

    public class AttackCommand : Command
    {
        public AttackCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string attackerName = commandArgs[1];
            string targetName = commandArgs[2];
            IStarship attackingShip = null, targetShip = null;
            attackingShip = GameEngine.Starships.FirstOrDefault(a => a.Name == attackerName);
            targetShip = GameEngine.Starships.FirstOrDefault(a => a.Name == targetName);
            ProcessStarshipBattle(attackingShip, targetShip);
        }

        private void ProcessStarshipBattle(IStarship attackingShip, IStarship targetShip)
        {
            base.ValidateAlive(attackingShip);
            base.ValidateAlive(targetShip);
            if (attackingShip.Location != targetShip.Location)
            {
                Console.WriteLine(Messages.NoSuchShipInStarSystem);
                return;
            }
            IProjectile attack = attackingShip.ProduceAttack();
            targetShip.RespondToAttack(attack);
            Console.WriteLine(Messages.ShipAttacked, attackingShip.Name, targetShip.Name);
            targetShip.Shields = (targetShip.Shields < 0) ? 0 : targetShip.Shields;
            if (targetShip.Health <= 0)
            {
                targetShip.Health = 0;
                Console.WriteLine(Messages.ShipDestroyed, targetShip.Name);
            }
        }
    }
}
