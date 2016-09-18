namespace Capitalism2.Core
{
    using System;
    using Commands;
    using Interfaces;

    public class Engine : IEngine
    {
        private readonly IDatabase database;

        public Engine(IDatabase database)
        {
            this.database = database;
        }

        public void Run()
        {
            IExecutable command = null;
            string line = Console.ReadLine();
            while (line != "end")
            {
                string[] tokens = line.Split();
                switch (tokens[0])
                {
                    case "create-company":
                        command = new CreateCompanyCommand(database,
                            tokens[1],
                            tokens[2],
                            tokens[3],
                            decimal.Parse(tokens[4]));
                        break;
                    case "create-employee":
                        string departmentName = null;
                        if (tokens.Length > 5)
                        {
                            departmentName = tokens[5];
                        }
                        command = new CreateEmployeeCommand(database,
                            tokens[1],
                            tokens[2],
                            tokens[3],
                            tokens[4],
                            departmentName);
                        break;
                    case "create-department":
                        string mainDepartmentName = null;
                        if (tokens.Length > 5)
                        {
                            mainDepartmentName = tokens[5];
                        }
                        command = new CreateDepartmentCommand(database,
                            tokens[1],
                            tokens[2],
                            tokens[3],
                            tokens[4],
                            mainDepartmentName);
                        break;
                    case "pay-salaries":
                        command = new PaySalariesCommand(tokens[1], database);
                        break;
                    case "show-employees":
                        command = new ShowEmployeesCommand(tokens[1], database);
                        break;
                }
                try
                {
                    Console.Write(command.Execute());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    line = Console.ReadLine();
                }
            }
        }
    }
}
