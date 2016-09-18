using System;
using System.Linq;
using System.Reflection;
using System.Text;
using Capitalism.Interfaces;
using Capitalism.Models;
using Capitalism.Models.Interfaces;
using Capitalism.Salaries;

namespace Capitalism.Execution
{
    class CapitalismCommandExecutor : ICommandExecutor
    {
        private const string BaseModelNamespace = "Capitalism.Models.";

        private IDatabase database;
        private SalaryManager salaryManager;
        public CapitalismCommandExecutor()
        {
            this.database = new CapitalismDatabase();
            this.salaryManager = new SalaryManager();
        }
        public string ExecuteCommand(ICommand command)
        {
            string commandResult = null;
            switch (command.Name)
            {
                case "create-company":
                    commandResult = ExecuteCreateCompanyCommand(command);
                    break;
                case "create-department":
                    commandResult = ExecuteCreateDepartmentCommand(command);
                    break;
                case "create-employee":
                    commandResult = ExecuteCreateEmployeeCommand(command);
                    break;
                case "pay-salaries":
                    commandResult = ExecutePaySalariesCommand(command);
                    break;
                case "show-employees":
                    commandResult = ExecuteShowEmployeesCommand(command);
                    break;
                case "end":
                    break;
                default:
                    throw new InvalidOperationException("The command name is invalid.");
            }
            return commandResult;
        }

        private string ExecuteShowEmployeesCommand(ICommand command)
        {
            string companyName = command.Parameters[0];
            var company = this.database.Companies.FirstOrDefault(c => c.Name == companyName);
            if (company == null)
            {
                return string.Format("Company {0} does not exist", companyName);
            }
            var output = new StringBuilder();
            output.AppendFormat("({0})", company.Name).AppendLine();
            output.AppendFormat("{0} {1} ({2:F2})",
                company.CEO.FirstName,
                company.CEO.LastName,
                this.database.TotalSalaries[company.CEO]).AppendLine();
            foreach (var employee in company.Employee)
            {
                output.AppendFormat("{0} {1} ({2:f2})",
                    employee.FirstName,
                    employee.LastName, this.database.TotalSalaries[employee]).AppendLine();
            }
            foreach (var department in company.Department)
            {
                DisplayDepartment(department, output, 1);
            }
            return output.ToString().Trim();
        }

        private void DisplayDepartment(Department department, StringBuilder output, int departmentLevel)
        {
            output.AppendFormat("{0}({1})", new string(' ', 4*departmentLevel), department.Name).AppendLine();
            foreach (var employee in department.Employee)
            {
                output.AppendFormat("{0}{1} {2} ({3:F2})",
                    new string(' ', 4*departmentLevel),
                    employee.FirstName,
                    employee.LastName,
                    this.database.TotalSalaries[employee])
                    .AppendLine();
            }
            foreach (var subDepartment in department.SubDepartments)
            {
                DisplayDepartment(subDepartment, output, departmentLevel + 1);
            }
        }

        private string ExecutePaySalariesCommand(ICommand command)
        {
            var companyName = command.Parameters[0];
            var company = this.database.Companies.FirstOrDefault(c => c.Name == companyName);
            if (company == null)
            {
                return string.Format("Company {0} does not exist", companyName);
            }
            var output = new StringBuilder();
            this.database.TotalSalaries[company.CEO] += company.CEO.Salary;
            decimal totalMoneyPaid = company.CEO.Salary;

            foreach (var employee in company.Employee)
            {
                this.database.TotalSalaries[employee] += employee.Salary;
                totalMoneyPaid += employee.Salary;
            }
            foreach (var department in company.Department)
            {
                totalMoneyPaid += PaySalariesToDepartment(department, output, 1);
            }
            output.AppendFormat("{0} ({1:F2})", company.Name, totalMoneyPaid).AppendLine();
            return string.Join(Environment.NewLine, output.ToString()
                    .Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
                    .Reverse());
        }

        private decimal PaySalariesToDepartment(Department department, StringBuilder output, int departmentLevel)
        {
            decimal totalMoneyPerDepartment = 0m;
            foreach (var employee in department.Employee)
            {
                this.database.TotalSalaries[employee] += employee.Salary;
                totalMoneyPerDepartment += employee.Salary;
            }
            totalMoneyPerDepartment += department.SubDepartments.Sum(subDepartment => PaySalariesToDepartment(subDepartment, output, departmentLevel + 1));
            output.AppendFormat("{0}{1} ({2:F2})",
                new string(' ', 4*departmentLevel), department.Name, totalMoneyPerDepartment)
                .AppendLine();
            return totalMoneyPerDepartment;
        }

        private string ExecuteCreateEmployeeCommand(ICommand command)
        {
            string companyName = command.Parameters[3];
            var company = this.database.Companies.FirstOrDefault(c => c.Name == companyName);
            if (company == null)
            {
                return string.Format("Company {0} does not exist", companyName);
            }
            string firstName = command.Parameters[0];
            string lastName = command.Parameters[1];
            if (company.Employee.Any(e => e.FirstName == firstName && e.LastName == lastName))
            {
                return string
                    .Format("Employee {0} {1} already exists in {2} (no department)",
                        firstName, lastName, companyName);
            }
            var firstConflictingEmployee = company
                .Department
                .SelectMany(d => d.Employee)
                .FirstOrDefault(e => e.FirstName == firstName && e.LastName == lastName);
            if (firstConflictingEmployee != null)
            {
                return string.Format("Employee {0} {1} already exists in {2} (in department {3})",
                    firstName, lastName, company.Name, firstConflictingEmployee);
            }
            var employeeTypeName = command.Parameters[2];
            var employeeType = Assembly
                .GetExecutingAssembly()
                .GetType(BaseModelNamespace + employeeTypeName);

            var employee = Activator
                .CreateInstance(employeeType, new object[] {command.Parameters[0], command.Parameters[1]}) as IEmployee;
            if (command.Parameters.Count == 4)
            {
                company.Employee.Add(employee);
                company.CEO.SubordinateEmployees.Add(employee);
            }
            else
            {
                string departmentName = command.Parameters[4];
                var department = GetDepartment(company, departmentName);
                if (department == null)
                {
                    department = company
                        .Department
                        .SelectMany(d => d.SubDepartments)
                        .FirstOrDefault(sd => sd.Name == departmentName);
                }
                if (department == null)
                {
                    return string.Format("Department {0} does not exist in company {1}", departmentName, company.Name);
                }
                department.Employee.Add(employee);
                department.Manager.SubordinateEmployees.Add(employee);
                employee.Department = department;
            }
            decimal salary = salaryManager.GetSalary(employee, company);
            employee.Salary = salary;
            this.database.TotalSalaries[employee] = 0m;
            return null;
        }

        private string ExecuteCreateCompanyCommand(ICommand command)
        {
            var ceo = new CEO(command.Parameters[1], command.Parameters[2], decimal.Parse(command.Parameters[3]));
            this.database.TotalSalaries[ceo] = 0m;
            var company = new Company(command.Parameters[0], ceo);
            if (this.database.Companies.Any(c => c.Name == company.Name))
            {
                return string.Format("Company {0} already exists", company.Name);
            }
            this.database.Companies.Add(company);
            return null;
        }

        private string ExecuteCreateDepartmentCommand(ICommand command)
        {
            string companyName = command.Parameters[0];
            var company = this.database.Companies.FirstOrDefault(c => c.Name == companyName);
            if (company == null)
            {
                return string.Format("Company {0} does not exist", companyName);
            }
            if (command.Parameters.Count == 4)
            {
                return ExecuteCreateDepartmentInCompanyCommand(command, company);
            }
            else
            {
                return ExecuteCreateSubDepartmentCommand(command, company);
            }
        }

        private string ExecuteCreateSubDepartmentCommand(ICommand command, Company company)
        {
            string mainDepartmentName = command.Parameters[4];
            var mainDepartment = GetDepartment(company, mainDepartmentName);
            if (mainDepartment == null)
            {
                return string.Format("There is no department {0} in {1}",
                    mainDepartmentName, company.Name);
            }
            string managerFirstName = command.Parameters[2];
            string managerLastName = command.Parameters[3];
            var manager = GetEmployeeByName(mainDepartment, managerFirstName, managerLastName);

            if (manager == null)
            {
                return string
                    .Format("There is no employee called {0} {1} in department {2}",
                        managerFirstName, managerLastName, mainDepartmentName);
            }
            try
            {
                CheckEmployeeIsManager(manager);
            }
            catch (ArgumentException ex)
            { 
                return ex.Message;
            }
            string departmentName = command.Parameters[1];
            if (mainDepartment.SubDepartments.Any(sd => sd.Name == departmentName))
            {
                return string.Format("Department {0} already exists in {1}",
                    departmentName, mainDepartment.Name);
            }
            if (company.Department.Any(d => d.Name == departmentName))
            {
                return string.Format("Department {0} already exists in {2}",
                    departmentName, company.Name);
            }
            var department = new Department(departmentName, manager as Manager);
            mainDepartment.SubDepartments.Add(department);
            return null;
        }

        private static Department GetDepartment(Company company, string mainDepartmentName)
        {
            var mainDepartment = company.Department.FirstOrDefault(d => d.Name == mainDepartmentName);
            var subDepartments = company.Department.SelectMany(d => d.SubDepartments);
            while (mainDepartment == null && subDepartments.Any())
            {
                mainDepartment = subDepartments.FirstOrDefault(sd => sd.Name == mainDepartmentName);
                subDepartments = subDepartments.SelectMany(sd => sd.SubDepartments);
            }
            return mainDepartment;
        }

        private string ExecuteCreateDepartmentInCompanyCommand(ICommand command, Company company)
        {
            string managerFirstName = command.Parameters[2];
            string managerLastName = command.Parameters[3];
            var manager = GetEmployeeByName(company, managerFirstName, managerLastName);
            if (manager == null)
            {
                return string
                    .Format("There is no employee called {0} {1} in company {2}",
                        managerFirstName, managerLastName, company.Name);
            }
            try
            {
                CheckEmployeeIsManager(manager);
            }
            catch (ArgumentException ex)
            {
                
                return ex.Message;
            }
            string departmentName = command.Parameters[1];
            if (company.Department.Any(d => d.Name == departmentName))
            {
                return string
                    .Format("Department {0} already exists in {1}",
                        departmentName, company.Name);
            }
            var department = new Department(departmentName, manager as Manager);
            company.Department.Add(department);
            return null;
        }


        private static void CheckEmployeeIsManager(IEmployee employeeToCheck)
        {
            if (!(employeeToCheck is Manager))
            {
                string position = employeeToCheck.GetType().Name;
                string realPosition = position[0].ToString();
                for (int i = 1; i < position.Length; i++)
                {
                    if (realPosition[i].ToString().ToUpper() == realPosition[i].ToString())
                    {
                        realPosition += " " + position[i];
                    }
                    else
                    {
                        realPosition += position[i];
                    }
                }
                throw new ArgumentException(string
                    .Format("{0} {1} is not a manager (real position: {2})",
                    employeeToCheck.FirstName, employeeToCheck.LastName, realPosition));
            }
        }

        private static IEmployee GetEmployeeByName(ICompanyStructure structure, string firstName, string lastName)
        {
            return structure
                .Employee
                .FirstOrDefault(e => e.FirstName == firstName && e.LastName == lastName);
        }
    }
}
