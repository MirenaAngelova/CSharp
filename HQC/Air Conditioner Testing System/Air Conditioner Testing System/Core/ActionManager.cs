using System;
using Air_Conditioner_Testing_System.Constants;
using Air_Conditioner_Testing_System.Databases;
using Air_Conditioner_Testing_System.Interfaces;

namespace Air_Conditioner_Testing_System.Core
{
    public class ActionManager : IActionManager
    {
        private IController controller;

        public ActionManager(IController controller)
        {
            this.controller = controller;
        }

        public ActionManager() :this(new Controller())
        {
        }

        public string ExecuteCommand(ICommand command)
        {
            var name = command.Name;
            try
            {
                switch (name)
                {
                    case "RegisterStationaryAirConditioner":
                        this.ValidateParametersCount(command, 4);
                        return this.controller.RegisterStationaryAirConditioner(
                            command.Parameters[0],
                            command.Parameters[1],
                            command.Parameters[2],
                            int.Parse(command.Parameters[3]));
                    case "RegisterCarAirConditioner":
                        this.ValidateParametersCount(command, 3);
                        return this.controller.RegisterCarAirConditioner(
                            command.Parameters[0],
                            command.Parameters[1],
                            int.Parse(command.Parameters[2]));
                    case "RegisterPlaneAirConditioner":
                        this.ValidateParametersCount(command, 4);
                        return this.controller.RegisterPlaneAirConditioner(
                            command.Parameters[0],
                            command.Parameters[1],
                            int.Parse(command.Parameters[2]),
                            int.Parse(command.Parameters[3]));
                    case "TestAirConditioner":
                        this.ValidateParametersCount(command, 2);
                        return this.controller.TestAirConditioner(
                            command.Parameters[0],
                            command.Parameters[1]);
                    case "FindAirConditioner":
                        this.ValidateParametersCount(command, 2);
                        return this.controller.FindAirConditioner(
                            command.Parameters[0],
                            command.Parameters[1]);
                    case "FindReport":
                        this.ValidateParametersCount(command, 2);
                        return this.controller.FindReport(
                            command.Parameters[0],
                            command.Parameters[1]);
                    case "FindAllReportsByManufacturer":
                        this.ValidateParametersCount(command, 1);
                        return this.controller.FindAllReportsByManufacturer(
                            command.Parameters[0]);
                    case "Status":
                        this.ValidateParametersCount(command, 0);
                        return this.controller.Status();
                    default:
                        throw new IndexOutOfRangeException(Constant.InvalidCommand);
                }
            }
            catch (FormatException ex)
            {
                throw new InvalidOperationException(Constant.InvalidCommand, ex.InnerException);
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new InvalidOperationException(Constant.InvalidCommand, ex.InnerException);
            }
        }

        public void ValidateParametersCount(ICommand command, int count)
        {
            if (command.Parameters.Length != count)
            {
                throw new InvalidOperationException(Constant.InvalidCommand);
            }
        }
    }
}
