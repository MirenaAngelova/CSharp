namespace Exam_Preparation_Capitalism.Core.Commands
{
    using Interfaces;
    public abstract class CommandAbstract : IExecutable
    {
        protected readonly IDatabase db;
        protected CommandAbstract(IDatabase db)
        {
            this.db = db;
        }

        public abstract string Execute();
    }
}
