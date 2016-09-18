using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empires6.Core;
using Empires6.Core.Factories;
using Empires6.IO;

namespace Empires6
{
    public class Program
    {
        static void Main()
        {
            var engine = new Engine(new BuildingFactory(), 
                new UnitFactory(), 
                new ResourceFactory(), 
                new ConsoleReadLine(), 
                new ConsoleWriteLine(), 
                new Database());
            engine.Run();
        }
    }
}
