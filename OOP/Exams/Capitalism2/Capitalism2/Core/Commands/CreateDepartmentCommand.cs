namespace Capitalism2.Core.Commands
{
    using System;
    using System.Linq;

    using Interfaces;
    using Models.Employees;
    using Models.Interfaces;
    using Models.OrganizationalUnits;

    public class CreateDepartmentCommand : CommandAbstract
    {
        private string companyName;
        private string departmentName;
        private string managerFirstName;
        private string managerLastName;
        private string mainDepartmentName;

        public CreateDepartmentCommand(
            IDatabase database,
            string companyName,
            string departmentName,
            string managerFirstName,
            string managerLastName,
            string mainDepartmentName = null)
            : base(database)
        {
            this.companyName = companyName;
            this.departmentName = departmentName;
            this.managerFirstName = managerFirstName;
            this.managerLastName = managerLastName;
            this.mainDepartmentName = mainDepartmentName;
        }

        public override string Execute()
        {
            Company company = this.database.Companies.Cast<Company>().FirstOrDefault(c => c.Name == this.companyName);

            if (company == null)
            {
                throw new ArgumentException($"Company {this.companyName}  does not exist");
            }

            IEmployee manager = null;
            IOrganizationalUnit mainDepartment = null;
            if (this.mainDepartmentName == null)
            {
                foreach (IEmployee employee in company.Employees)
                {
                    if (employee.FirstName == this.managerFirstName && employee.LastName == this.managerLastName)
                    {
                        manager = employee;
                        break;
                    }
                }

                if (manager == null)
                {
                    throw new ArgumentException(
                        $"There is no employee called {this.managerFirstName} {this.managerLastName} " +
                        $"in company {this.companyName}");
                }
            }
            else
            {
                foreach (IOrganizationalUnit d in company.AllDepartments)
                {
                    if (d.Name == this.mainDepartmentName)
                    {
                        mainDepartment = d;
                        break;
                    }
                }

                if (mainDepartment == null)
                {
                    throw new ArgumentException($"There is no department {this.mainDepartmentName} in {this.companyName}");
                }

                foreach (IEmployee employee in mainDepartment.Employees)
                {
                    if (employee.FirstName == this.managerFirstName && employee.LastName == this.managerLastName)
                    {
                        manager = employee;
                        break;
                    }
                }

                if (manager == null)
                {
                    throw new ArgumentException(
                        $"There is no employee called {this.managerFirstName} {this.managerLastName}" +
                        $" in department {this.mainDepartmentName}");
                }
            }

            if (!(manager is Manager))
            {
                string realPosition = manager.GetType().Name;
                throw new TypeLoadException(
                    $"{this.managerFirstName} {this.managerLastName} is not a manager (real position: {realPosition})");
            }

            if (company.SubUnits.Any(d => d.Name == this.departmentName))
            {
                throw new ArgumentException($"Department {this.departmentName} already exists in {this.companyName}");
            }

            IOrganizationalUnit department = new Department(this.departmentName);
            department.Head = manager;
            if (this.mainDepartmentName != null)
            {
                mainDepartment.AddSubUnit(department);
            }
            else
            {
                company.AddSubUnit(department);
            }

            company.AllDepartments.Add(department);
            return "";
        }
    }
}
