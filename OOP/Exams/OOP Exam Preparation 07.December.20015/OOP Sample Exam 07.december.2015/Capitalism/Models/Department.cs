using System;
using System.Collections.Generic;
using Capitalism.Models.Interfaces;

namespace Capitalism.Models
{
    public class Department : ICompanyStructure
    {
        private string name;
        private Manager manager;

        public Department(string name, Manager manager)
        {
            this.Name = name;
            this.Manager = manager;
            this.Employee = new List<IEmployee>();
            this.SubDepartments = new List<Department>();
        }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException("Name", "The name should be valid.");
                }
                this.name = value;
            }
        }
        public Manager Manager
        {
            get { return this.manager; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("manager", "The deparmant must have a manager.");
                }
                this.manager = value;
            }
        }
        public ICollection<IEmployee> Employee { get; set; }
        public ICollection<Department> SubDepartments { get; set; }
    }
}
