namespace Blobs2.Core
{
    using System;
    using System.Linq;

    using Interfaces;
    using Models.Events;

    public class Engine : IEngine
    {
        private readonly IBlobFactory blobFactory;
        private readonly IAttackFactory attackFactory;
        private readonly IBehaviorFactory behaviorFactory;
        private readonly IInputReader reader;
        private readonly IOutputWriter writer;
        private readonly IBlobData data;

        private bool shouldReportEvents;

        public Engine(
            IBlobFactory blobFactory,
            IAttackFactory attackFactory,
            IBehaviorFactory behaviorFactory,
            IInputReader reader,
            IOutputWriter writer,
            IBlobData data)
        {
            this.blobFactory = blobFactory;
            this.attackFactory = attackFactory;
            this.behaviorFactory = behaviorFactory;
            this.reader = reader;
            this.writer = writer;
            this.data = data;

            this.shouldReportEvents = false;
        }

        public virtual void Run()
        {
            while (true)
            {
                var input = this.reader.ReadLine();
                this.ExecuteInput(input.Split());
                this.UpdateBlobs();
            }
        }

        private void UpdateBlobs()
        {
            foreach (var blob in this.data.Blobs.Where(b => b.Behavior.IsTriggered))
            {
                blob.Update();
            }
        }

        protected virtual void ExecuteInput(string[] args)
        {
            string command = args[0];
            switch (command)
            {
                case "create":
                    this.ExecuteCreateCommand(args);
                    break;
                case "attack":
                    this.ExecuteAttackCommand(args);
                    break;
                case "pass":
                    break;
                case "status":
                    this.ExecuteStatusReportCommand();
                    break;
                case "report-events":
                    this.shouldReportEvents = true;
                    break;
                case "drop":
                    Environment.Exit(0);
                    break;
                default:
                    throw new ArgumentException("Undefined command.");
            }
        }

        private void ExecuteStatusReportCommand()
        {
            string output = String.Join("\n", this.data.Blobs);
            this.writer.Write(output);
        }

        private void ExecuteAttackCommand(string[] attackArgs)
        {
            var attackerName = attackArgs[1];
            var targetName = attackArgs[2];

            var attacker = this.data.Blobs.FirstOrDefault(b => b.Name == attackerName);
            var target = this.data.Blobs.FirstOrDefault(b => b.Name == targetName);
            if (attacker == null || target == null)
            {
                throw new ArgumentException("Blob was not found.");
            }

            if (attacker.IsAlive && target.IsAlive)
            {
                attacker.PerformAttack(target);
            }

        }

        private void ExecuteCreateCommand(string[] creationArgs)
        {
            var name = creationArgs[1];
            int health = int.Parse(creationArgs[2]);
            int damage = int.Parse(creationArgs[3]);

            var behaviorType = creationArgs[4];
            var behavior = behaviorFactory.Create(behaviorType);

            string attackType = creationArgs[5];
            var attack = attackFactory.Create(attackType);

            var blob = blobFactory.Create(name, health, damage, behavior, attack);
            if (shouldReportEvents)
            {
                blob.OnBehaviorToggled += this.PrintBehaviorToggled;
                blob.OnBlobDead += this.PrintBlobDead;
            }

            this.data.AddBlob(blob);
        }

        private void PrintBlobDead(object sender, BlobDeadEventArgs e)
        {
            this.writer.Write(e.Message);
        }

        private void PrintBehaviorToggled(object sender, BehaviorToggledEventArgs e)
        {
            this.writer.Write(e.Message);
        }
    }
}
