using System;
using Air_Conditioner_Testing_System.Constants;
using Air_Conditioner_Testing_System.Interfaces;
using Air_Conditioner_Testing_System.UI;

namespace Air_Conditioner_Testing_System.Core
{
    public class Engine : IEngine
    {
        public Engine(IActionManager actionManager, IUserInterface userInterface)
        {
            this.ActionManager = actionManager;
            this.UserInterface = userInterface;
        }

        public Engine() : this(new ActionManager(), new ConsoleUserInterface())
        {

        }

        public IUserInterface UserInterface { get; }

        public IActionManager ActionManager { get; }

        public void Run()
        {
            while (true)
            {
                string line = this.UserInterface.ReadLine();
                if (string.IsNullOrEmpty(line))
                {
                    break;
                }

                line = line.Trim();
                try
                {
                    var command = new Command(line);
                    string commandResult = this.ActionManager.ExecuteCommand(command);
                    this.UserInterface.WriteLine(commandResult);
                }
                catch (Exception ex)
                {
                    this.UserInterface.WriteLine(ex.Message);
                }
            }
        }

    }
}
