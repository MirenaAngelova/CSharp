using System.Collections.Generic;

namespace Exam_Preparation_Capitalism.OrganizationalUnits
{
    using Interfaces;
    public class Company : IOrganizationalUnits
    {

        private readonly IList<IOrganizationalUnits> subUnits;
        private readonly IList<IEmployee> employees;
        private readonly IList<IEmployee> allEmployees;
        private readonly IList<IOrganizationalUnits> allDepatments;

        public Company(string name)
        {
            this.subUnits = new List<IOrganizationalUnits>();
            this.employees = new List<IEmployee>();
            this.allEmployees = new List<IEmployee>();
            this.allDepatments = new List<IOrganizationalUnits>();
            this.Name = name;

        }

        public string Name { get; private set; }

        public IList<IOrganizationalUnits> AllDepartments {get { return this.allDepatments; } }

        public IList<IEmployee> AllEmployees {get { return this.allEmployees; } }

        public IEnumerable<IEmployee> Employees { get { return this.employees; } }
        public IEnumerable<IOrganizationalUnits> SubUnits { get { return this.subUnits; } }
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
