namespace Capitalism2.Core.Commands
{
    using System;
    using System.Linq;

    using Factories;
    using Interfaces;
    using Models.Interfaces;
    using Models.OrganizationalUnits;

    public class CreateCompanyCommand : CommandAbstract
    {
        private string companyName;
        private string ceoFirstName;
        private string ceoLastName;
        private decimal ceoSalary;

        public CreateCompanyCommand(
            IDatabase database,
            string companyName,
            string ceoFirstName,
            string ceoLastName,
            decimal ceoSalary)
            : base(database)
        {
            this.companyName = companyName;
            this.ceoFirstName = ceoFirstName;
            this.ceoLastName = ceoLastName;
            this.ceoSalary = ceoSalary;
        }

        public override string Execute()
        {
            if (this.database.Companies.Any(c => c.Name == this.companyName))
            {
                throw new Exception($"Company {this.companyName} already exists");
            }

            IOrganizationalUnit company = new Company(this.companyName);
            IEmployee ceo = EmployeeFactory.Create(this.ceoFirstName, this.ceoLastName, "CEO", company, this.ceoSalary);
            this.database.AddCompany(company);
            company.AddEmployee(ceo);
            company.Head = ceo;
            return "";
        }
    }
}
