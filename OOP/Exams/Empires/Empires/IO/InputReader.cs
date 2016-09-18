namespace Empires.IO
{
    using System;

    using Interfaces;

    public class InputReader : IInputReader
    {
        public string ReadLine()
        {
            string inputLine = Console.ReadLine();

            return inputLine;
        }
    }
}
