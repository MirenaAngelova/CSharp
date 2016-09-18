using System;
using Empires6.Interfaces;

namespace Empires6.IO
{
    public class ConsoleWriteLine : IOutputWriter
    {
        public void WriteLine(string output)
        {
            Console.Write(output);
        }
    }
}