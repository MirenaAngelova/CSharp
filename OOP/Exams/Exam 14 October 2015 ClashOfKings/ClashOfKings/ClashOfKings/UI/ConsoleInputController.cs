namespace ClashOfKings.UI
{
    using System;
    using Contracts;

    public class ConsoleInputController : IInputController
    {
        public string ReadInput()
        {
            string inputLine = Console.ReadLine();
            return inputLine;
        }
    }
}