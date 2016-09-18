using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Company_Hierarchy
{
    class Manager : Employee, IManager
    {
        private List<IEmployee> staff;

        public Manager(string firstName, string lastName, int id, decimal salary, Department department, 
            List<IEmployee> staff )
            : base(firstName, lastName, id, salary, department)
        {
            this.Staff = staff;
        }

        public Manager(string firstName, string lastName, int id, decimal salary, Department department, IEmployee employee)
            : this(firstName, lastName, id, salary, department, new List<IEmployee>{ employee })
        {
        }

        public List<IEmployee> Staff { get; set; }
        public override string ToString()
        {
            StringBuilder exit = new StringBuilder();
            exit.Append(base.ToString());
            exit.Append(string.Format("Manager of Department {0}{1}", this.Department, Environment.NewLine));
            exit.Append(string.Format("Managed {0} employees{1}", this.Staff.Count, Environment.NewLine));
            foreach (IEmployee employee in this.Staff)
            {
                exit.Append(string.Format("-ID: {0} - Name: {1} {2}", employee.ID, employee.FirstName, employee.LastName));
            }
            return exit.ToString();
        }
    }
}
