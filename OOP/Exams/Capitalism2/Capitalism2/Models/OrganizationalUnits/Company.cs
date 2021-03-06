﻿namespace Capitalism2.Models.OrganizationalUnits
{
    using System.Collections.Generic;

    using Interfaces;

    public class Company : IOrganizationalUnit
    {
        private readonly IList<IOrganizationalUnit> subUnits;
        private readonly IList<IOrganizationalUnit> allDepartments; 
        private readonly IList<IEmployee> employees; 
        private readonly IList<IEmployee> allEmployees;

        public Company(string name)
        {
            this.subUnits = new List<IOrganizationalUnit>();
            this.employees = new List<IEmployee>();
            this.allEmployees = new List<IEmployee>();
            this.allDepartments = new List<IOrganizationalUnit>();
            this.Name = name;
        }

        public string Name { get; private set; }

        public IEnumerable<IOrganizationalUnit> SubUnits => this.subUnits;

        public IList<IOrganizationalUnit> AllDepartments => this.allDepartments;
        
        public IEnumerable<IEmployee> Employees => this.employees;

        public IList<IEmployee> AllEmployees => this.allEmployees;

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
