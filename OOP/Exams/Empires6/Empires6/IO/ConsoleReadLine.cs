using System;
using Empires6.Interfaces;

namespace Empires6.IO
{
    public class ConsoleReadLine : IInputReader
    {
        public string ReadLine()
        {
            string inputLine = Console.ReadLine();

            return inputLine;
        }
    }
}