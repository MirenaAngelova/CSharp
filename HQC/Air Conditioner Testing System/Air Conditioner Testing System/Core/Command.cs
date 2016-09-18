using System;
using Air_Conditioner_Testing_System.Constants;
using Air_Conditioner_Testing_System.Interfaces;

namespace Air_Conditioner_Testing_System.Core
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

        public string Name { get; set; }

        public string[] Parameters { get; set; }
    }
}
