using System;
using Air_Conditioner_Testing_System6.Constants;
using Air_Conditioner_Testing_System6.Interfaces;

namespace Air_Conditioner_Testing_System6.Core
{
    public class Command : ICommand
    {
        public Command(string line)
        {
            try
            {
                this.Name = line.Substring(0, line.IndexOf(' '));

                this.Parameters = line.Substring(line.IndexOf(' ') + 1)
                    .Split(new char[] { '(', ')', ',' }, StringSplitOptions.RemoveEmptyEntries);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(Constant.InvalidCommand, ex);
            }
        }

        public string Name { get; private set; }

        public string[] Parameters { get; private set; }
    }
}
