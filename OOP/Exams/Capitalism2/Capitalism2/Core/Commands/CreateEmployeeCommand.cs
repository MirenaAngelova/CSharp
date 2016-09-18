namespace Capitalism2.Core.Commands
{
    using System;
    using System.Linq;

    using Factories;
    using Interfaces;
    using Models.Interfaces;
    using Models.OrganizationalUnits;

    public class CreateEmployeeCommand : CommandAbstract
    {
        private string companyName;
        private string departmentName;
        private string firstName;
        private string lastName;
        private string position;

        public CreateEmployeeCommand(
            IDatabase database,
            string firstName,
            string lastName, 
            string position,
            string companyName,
            string departmentName = null) 
            : base(database)
        {
            this.companyName = companyName;
            this.departmentName = departmentName;
            this.firstName = firstName;
            this.lastName = lastName;
            this.position = position;
        }

        public override string Execute()
        {
            Company company = this.database.Companies.Cast<Company>().FirstOrDefault(c => c.Name == this.companyName);

            if (company == null)
            {
                throw new ArgumentException($"Company {this.companyName} does not exist");
            }

            foreach (IEmployee e in company.AllEmployees)
            {
                if (e.FirstName == this.firstName && e.LastName == this.lastName)
                {
                    if (e.InUnit is Company)
                    {
                        throw new ArgumentException(
                            $"Employee {this.firstName} {this.lastName} already exists in" +
                            $" {this.companyName} (no department)");
                    }
                    else
                    {
                        throw new ArgumentException($"Employee {this.firstName} {this.lastName} already exists in" +
                                                    $" {this.companyName} (in department {e.InUnit.Name})");
                    }
                }
            }

            IOrganizationalUnit inUnit = company;
            if (this.departmentName != null)
            {
                foreach (IOrganizationalUnit department in company.AllDepartments)
                {
                    if (department.Name == this.departmentName)
                    {
                        inUnit = department;
                        break;
                    }
                }
            }

            IEmployee employee = EmployeeFactory.Create(this.firstName, this.lastName, this.position, inUnit);
            company.AllEmployees.Add(employee);
            inUnit.AddEmployee(employee);
            return "";
        }
    }
}
