using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Air_Conditioner_Testing_System6.Constants;
using Air_Conditioner_Testing_System6.Interfaces;

namespace Air_Conditioner_Testing_System6.Core
{
    public class ActionManager : IActionManager
    {
        public ActionManager(IController controller)
        {
            this.Controller = controller;
        }

        public ActionManager() : this(new Controller())
        {
        }

        public IController Controller { get; private set; }

        public string ExecuteCommand(ICommand command)
        {
            string commandName = command.Name;
            try
            {
                switch (commandName)
                {
                    case "RegisterStationaryAirConditioner":
                        this.ValidateParametersCount(command, Constant.RegisterStationaryParametersCount);
                        return this.Controller.RegisterStationaryAirConditioner(
                            command.Parameters[0],
                            command.Parameters[1],
                            command.Parameters[2],
                            int.Parse(command.Parameters[3]));
                    case "RegisterCarAirConditioner":
                        this.ValidateParametersCount(command, Constant.RegisterCarParametersCount);
                        return this.Controller.RegisterCarAirConditioner(
                            command.Parameters[0],
                            command.Parameters[1],
                            int.Parse(command.Parameters[2]));
                    case "RegisterPlaneAirConditioner":
                        this.ValidateParametersCount(command, Constant.RegisterPlaneParametersCount);
                        return this.Controller.RegisterPlaneAirConditioner(
                            command.Parameters[0],
                            command.Parameters[1],
                            int.Parse(command.Parameters[2]),
                            int.Parse(command.Parameters[3]));
                    case "TestAirConditioner":
                        this.ValidateParametersCount(command, Constant.TestParametersCount);
                        return this.Controller.TestAirConditioner(
                            command.Parameters[0],
                            command.Parameters[1]);
                    case "FindAirConditioner":
                        this.ValidateParametersCount(command, Constant.FindConditionerParametersCount);
                        return this.Controller.FindAirConditioner(
                            command.Parameters[0],
                            command.Parameters[1]);
                    case "FindReport":
                        this.ValidateParametersCount(command, Constant.FindReportParametersCount);
                        return this.Controller.FindReport(
                            command.Parameters[0],
                            command.Parameters[1]);
                    case "FindAllReportsByManufacturer":
                        this.ValidateParametersCount(command, Constant.FindAllReportsParametersCount);
                        return this.Controller.FindAllReportsByManufacturer(
                            command.Parameters[0]);
                    case "Status":
                        this.ValidateParametersCount(command, Constant.StatusParametersCount);
                        return this.Controller.Status();
                    default:
                        throw new InvalidOperationException(Constant.InvalidCommand);
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
