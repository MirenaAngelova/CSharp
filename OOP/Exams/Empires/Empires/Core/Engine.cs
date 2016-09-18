namespace Empires.Core
{
    using System;
    using System.Linq;
    using System.Text;

    using Interfaces;
    using Models.EventArgs;

    public class Engine : IEngine
    {
        private readonly IBuildingFactory buildingFactory;
        private readonly IResourceFactory resourceFactory;
        private readonly IUnitFactory unitFactory;
        private readonly IDatabase database;
        private readonly IInputReader inputReader;
        private readonly IOutputWriter outputWriter;

        public Engine(
            IBuildingFactory buildingFactory,
            IResourceFactory resourceFactory,
            IUnitFactory unitFactory,
            IDatabase database,
            IInputReader inputReader,
            IOutputWriter outputWriter)
        {
            this.buildingFactory = buildingFactory;
            this.resourceFactory = resourceFactory;
            this.unitFactory = unitFactory;
            this.database = database;
            this.inputReader = inputReader;
            this.outputWriter = outputWriter;
        }

        public virtual void Run()
        {
            while (true)
            {
                string[] inputLine = this.inputReader.ReadLine().Split();
                this.ExecuteCommand(inputLine);
                this.UpdateBuildings();
            }
        }
        
        private void UpdateBuildings()
        {
            foreach (IBuilding building in this.database.Biuldings)
            {
                building.Update();
            }
        }

        protected virtual void ExecuteCommand(string[] inputLine)
        {
            string command = inputLine[0];
            switch (command)
            {
                case "build":
                    this.ExecuteBuildCommand(inputLine);
                    break;
                case "empire-status":
                    this.ExecuteStatusCommand();
                    break;
                case "skip":
                    break;
                case "armistice":
                    Environment.Exit(0);
                    break;
                default:
                    throw new ArgumentException("Invalid command");
            }
        }

        private void ExecuteStatusCommand()
        {
            PrintStatus();
        }

        private void PrintStatus()
        {
            var exit = new StringBuilder();
            this.AppendTreasury(exit);
            this.AppendBuilding(exit);
            this.AppendUnit(exit);

            this.outputWriter.WriteLine(exit.ToString());
        }

        private void AppendUnit(StringBuilder exit)
        {
            exit.AppendLine("Units:");
            if (this.database.Units.Any())
            {
                foreach (var unit in this.database.Units)
                {
                    exit.AppendLine($"--{unit.Key}: {unit.Value}");
                }
            }
            else
            {
                exit.AppendLine("N/A");
            }
        }

        private void AppendBuilding(StringBuilder exit)
        {
            exit.AppendLine("Buildings:");
            if (this.database.Biuldings.Any())
            {
                foreach (IBuilding building in this.database.Biuldings)
                {
                    exit.AppendLine(building.ToString());
                }
            }
            else
            {
                exit.AppendLine("N/A");
            }
        }

        private void AppendTreasury(StringBuilder exit)
        {
            exit.AppendLine("Treasury:");
            foreach (var resource in this.database.Resources)
            {
                exit.AppendLine($"--{resource.Key}: {resource.Value}");
            }
        }

        private void ExecuteBuildCommand(string[] inputLine)
        {
            string typeBuilding = inputLine[1];
            IBuilding building = this.buildingFactory
                .CreateBuilding(typeBuilding, this.unitFactory, this.resourceFactory);
            building.OnResourceProduced += AddResource;
            building.OnUnitProduced += AddUnit;
            this.database.AddBuilding(building);
        }

        private void AddUnit(object sender, UnitProducedEventArgs e)
        {
            var unit = e.Unit;
            this.database.AddUnits(unit);
        }

        private void AddResource(object sender, ResourceProducedEventArgs e)
        {
            var resource = e.Resource;
            this.database.Resources[resource.TypeResource] += resource.Quantity;
        }
    }
}
