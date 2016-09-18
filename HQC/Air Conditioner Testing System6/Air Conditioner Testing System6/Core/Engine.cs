using System;
using Air_Conditioner_Testing_System6.Constants;
using Air_Conditioner_Testing_System6.Interfaces;
using BigMani.UI;

namespace Air_Conditioner_Testing_System6.Core
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

        public IUserInterface UserInterface { get; set; }

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
                    this.UserInterface.WriteLine(this.ActionManager.ExecuteCommand(command));
                }
                catch (InvalidOperationException ex)
                {
                    this.UserInterface.WriteLine(ex.Message);
                }
            }
        }
    }
}
