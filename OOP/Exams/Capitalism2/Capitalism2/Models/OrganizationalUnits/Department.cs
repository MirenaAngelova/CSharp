namespace Capitalism2.Models.OrganizationalUnits
{
    using System.Collections.Generic;

    using Interfaces;

    public class Department : IOrganizationalUnit
    {
        private readonly IList<IOrganizationalUnit> subUnits; 
        private readonly IList<IEmployee> employees;

        public Department(string name)
        {
            this.subUnits = new List<IOrganizationalUnit>();
            this.employees = new List<IEmployee>();
            this.Name = name;
        }

        public string Name { get; private set; }

        public IEnumerable<IOrganizationalUnit> SubUnits => this.subUnits;

        public IEnumerable<IEmployee> Employees => this.employees;

        public IEmployee Head { get; set; }

        public void AddSubUnit(IOrganizationalUnit unit)
        {
            this.subUnits.Add(unit);
        }

        public void AddEmployee(IEmployee employee)
        {
            this.employees.Add(employee);
        }

        public void RemoveEmployee(IEmployee employee)
        {
            this.employees.Remove(employee);
        }
    }
}
