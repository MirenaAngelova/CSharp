namespace Capitalism2.Core.Commands
{
    using System;
    using System.Linq;
    using System.Text;

    using Interfaces;
    using Models.Employees;
    using Models.Interfaces;

    public class PaySalariesCommand : CommandAbstract
    {
        private string companyName;
        private CEO ceo;
        private StringBuilder output;

        public PaySalariesCommand(string companyName, IDatabase database) : base(database)
        {
            this.companyName = companyName;
            this.output = new StringBuilder();
        }

        public override string Execute()
        {
            IOrganizationalUnit company = this.database.Companies.FirstOrDefault(c => c.Name == this.companyName);
            if (company == null)
            {
                throw new ArgumentNullException($"Company {this.companyName} does not exist");
            }
            ceo = (CEO) company.Head;
            this.Pay(company, 0, 0);
            return this.output.ToString();
        }

        private decimal Pay(IOrganizationalUnit unit, decimal paid, int depth)
        {
            paid += unit.SubUnits.Sum(dep => this.Pay(dep, 0, depth + 1));

            paid += (from emp in unit.Employees let percents = (15 - depth)*0.01m
                     select emp.RecieveSalary(percents, this.ceo.Salary)).Sum();

            this.output.Insert(0, $"{new String(' ', depth*4)}{unit.Name} ({paid:F2}){Environment.NewLine}");
            return paid;
        }
    }
}
