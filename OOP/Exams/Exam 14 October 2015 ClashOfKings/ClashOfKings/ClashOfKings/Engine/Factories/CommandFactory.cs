namespace ClashOfKings.Engine.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Attributes;
    using Contracts;
    

    public class CommandFactory : ICommandFactory
    {
        public ICommand CreateCommand(string commandName, IGameEngine engine)
        {
            var commandType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(type => type.CustomAttributes.Any(a => a.AttributeType == typeof (CommandAttribute)) &&
                                        type.Name == commandName);

            if (commandType == null)
            {
                throw new ArgumentNullException(nameof(commandType), "Unknown command.");
            }

            var command = Activator.CreateInstance(commandType, engine) as ICommand;

            return command;
        }
    }
}
