using System;

namespace Empires.IO
{
    using Empires.Interfaces;
    public class ConsoleWriter : IOutputWriter
    {
        public void Print(string message)
        {
            Console.Write(message);
        }
    }
}
