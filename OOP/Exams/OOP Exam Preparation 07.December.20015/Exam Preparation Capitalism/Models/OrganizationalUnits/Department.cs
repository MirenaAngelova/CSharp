using System.Collections.Generic;

namespace Exam_Preparation_Capitalism.OrganizationalUnits
{
    using Interfaces;
    public class Department : IOrganizationalUnits
    {
        private readonly IList<IOrganizationalUnits> subUnits;
        private readonly IList<IEmployee> employees;
        public Department(string name)
        {
            this.subUnits = new List<IOrganizationalUnits>();
            this.employees = new List<IEmployee>();
            this.Name = name;
        }
        public string Name { get; private set; }
        public IEnumerable<IOrganizationalUnits> SubUnits{ get { return this.subUnits; } }

        public IEnumerable<IEmployee> Employees { get; private set; }
        public IEmployee Head { get; set; }
        public void AddSubUnit(IOrganizationalUnits unit)
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
