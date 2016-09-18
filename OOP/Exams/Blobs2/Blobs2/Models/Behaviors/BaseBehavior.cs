namespace Blobs2.Models.Behaviors
{
    using Interfaces;

    public abstract class BaseBehavior : IBehavior
    {
        protected const string ExceptionMessage = "A behavior can only be triggered once.";

        public bool IsTriggered { get; protected set; }

        public bool AlreadyTriggered { get; protected set; }

        protected bool ShouldDelayBeforeExecution { get; set; } = true;

        public abstract void Trigger(IBlob blob);

        public abstract void PerformNegativeEffects(IBlob blob);
    }
}
