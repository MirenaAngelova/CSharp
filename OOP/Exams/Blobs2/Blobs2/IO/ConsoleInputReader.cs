using System;
using System.Collections.Generic;
using System.Linq;
namespace Blobs2.IO
{
    using Interfaces;

    public class ConsoleInputReader : IInputReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
