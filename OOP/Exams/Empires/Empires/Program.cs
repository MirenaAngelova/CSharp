using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empires.Core;
using Empires.Core.Factories;
using Empires.Interfaces;
using Empires.IO;

namespace Empires
{
    public class Program
    {
        static void Main()
        {
            var buildingFactory = new BuildingsFactory();
            var resourceFactory = new ResourcesFactory();
            var unitFactory = new UnitsFactory();
            var database = new Database();
            var inputReader = new InputReader();
            var outputWriter = new OutputWriter();

            var engine = new Engine(
                buildingFactory,
                resourceFactory,
                unitFactory,
                database,
                inputReader,
                outputWriter);
            engine.Run();
        }
    }
}
