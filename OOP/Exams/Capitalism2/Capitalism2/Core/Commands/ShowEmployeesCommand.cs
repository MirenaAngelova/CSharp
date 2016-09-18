namespace Capitalism2.Core.Commands
{
    using System;
    using System.Linq;
    using System.Text;

    using Interfaces;
    using Models.Employees;
    using Models.Interfaces;

    public class ShowEmployeesCommand : CommandAbstract
    {
        private string companyName;
        private CEO ceo;
        private StringBuilder output; 

        public ShowEmployeesCommand(string companyName, IDatabase database) : base(database)
        {
            this.companyName = companyName;
        }

        public override string Execute()
        {
            IOrganizationalUnit company = this.database.Companies.FirstOrDefault(c => c.Name == this.companyName);
            if (company == null)
            {
                throw new ArgumentException($"Company {this.companyName} does not exist");
            }

            ceo = (CEO) company.Head;
            PrintHierarchy(company, 0);
            return "";
        }

        private void PrintHierarchy(IOrganizationalUnit unit, int depth)
        {
            Console.WriteLine("{0}({1})", new string(' ', depth * 4), unit.Name);
            foreach (IEmployee employee in unit.Employees)
            {
                Console.WriteLine("{0}{1} {2} ({3:F2})",
                    new string(' ', depth * 4), employee.FirstName, employee.LastName, employee.TotalPaid);
            }

            foreach (IOrganizationalUnit subUnit in unit.SubUnits)
            {
                this.PrintHierarchy(subUnit, depth + 1);
            }
        }
    }
}
