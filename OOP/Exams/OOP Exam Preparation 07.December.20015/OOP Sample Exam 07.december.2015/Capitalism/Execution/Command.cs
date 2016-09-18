using System;
using System.Collections.Generic;
using System.Linq;
using Capitalism.Interfaces;

namespace Capitalism.Execution
{
    public class Command : ICommand
    {
        public Command(string commandString)
        {
            string[] commandParts = commandString.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            this.Name = commandParts[0];
            if (commandParts.Length > 1)
            {
                this.Parameters = commandParts.Skip(1).ToArray();
            }
        }

        public IList<string> Parameters { get; set; }

        public string Name { get; set; }
    }
}
