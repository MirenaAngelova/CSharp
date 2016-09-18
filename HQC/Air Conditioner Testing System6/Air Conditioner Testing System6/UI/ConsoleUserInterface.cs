using Air_Conditioner_Testing_System6.Interfaces;

namespace BigMani.UI
{
    using System;

    public class ConsoleUserInterface : IUserInterface
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
