using System;
using Empires.Interfaces;

namespace Empires.IO
{
    public class OutputWriter : IOutputWriter
    {
        public void WriteLine(string message)
        {
           Console.Write(message);
        }
    }
}
