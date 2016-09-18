using System;
using System.Linq;
using System.Text;
using Empires6.Constants;
using Empires6.Interfaces;
using Empires6.Models.EventArgs;

namespace Empires6.Core
{
    public class Engine : IEngine
    {
        private IBuildingFactory buildingFactory;
        private IUnitFactory unitFactory;
        private IResourceFactory resourceFactory;
        private IInputReader inputReader;
        private IOutputWriter outputWriter;
        private IDatabase database;

        public Engine(
            IBuildingFactory buildingFactory, 
            IUnitFactory unitFactory, 
            IResourceFactory resourceFactory, 
            IInputReader inputReader, 
            IOutputWriter outputWriter, 
            IDatabase database)
        {
            this.buildingFactory = buildingFactory;
            this.unitFactory = unitFactory;
            this.resourceFactory = resourceFactory;
            this.inputReader = inputReader;
            this.outputWriter = outputWriter;
            this.database = database;
        }

        public void Run()
        {
            while (true)
            {
                string inputLine = this.inputReader.ReadLine();
                this.ExecuteCommand(inputLine.Split());
                this.UpdateBuildings();
            }
        }

        private void UpdateBuildings()
        {
            foreach (var building in this.database.Buildings)
            {
                building.Update();
            }
        }

        private void ExecuteCommand(string[] commands)
        {
            string command = commands[0];
            switch (command)
            {
                case "build":
                    this.ExecuteBuildCommand(commands);
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
                    throw new InvalidOperationException(Constant.IndefinedCommand);
            }
        }

        private void ExecuteStatusCommand()
        {
            StringBuilder exit = new StringBuilder();
            this.AppendTreasury(exit);
            this.AppendBuildings(exit);
            this.AppendUnits(exit);
            this.outputWriter.WriteLine(exit.ToString());
        }

        private void AppendUnits(StringBuilder exit)
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

        private void AppendBuildings(StringBuilder exit)
        {
            exit.AppendLine("Buildings:");
            if (this.database.Buildings.Any())
            {
                foreach (var building in this.database.Buildings)
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

        private void ExecuteBuildCommand(string[] commands)
        {
            string buildingType = commands[1];

            IBuilding building =
                this.buildingFactory.Create(buildingType, this.unitFactory, this.resourceFactory);
            building.OnUnitProduced += this.AddUnit;
            building.OnResourceProduced += this.AddResource;
            this.database.AddBuildings(building);
        }

        private void AddResource(object sender, ResourceProducedEventArgs e)
        {
            var resource = e.Resource;
            this.database.Resources[resource.ResourceType] += resource.Quantity;
        }

        private void AddUnit(object sender, UnitProducedEventArgs e)
        {
            var unit = e.Unit;
            this.database.AddUnits(unit);
        }
    }
}