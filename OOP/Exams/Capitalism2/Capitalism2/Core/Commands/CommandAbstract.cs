namespace Capitalism2.Core.Commands
{
    using Interfaces;

    public abstract class CommandAbstract : IExecutable
    {
        protected readonly IDatabase database;

        protected CommandAbstract(IDatabase database)
        {
            this.database = database;
        }

        public abstract string Execute();
    }
}