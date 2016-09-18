using System.Collections.Generic;
using Capitalism.Models.Interfaces;

namespace Capitalism.Models
{
    public class Manager : Employee, IBoss
    {
        public Manager(string firstName, string lastName, Department department) 
            : base(firstName, lastName, department)
        {
            this.SubordinateEmployees = new List<IEmployee>();
        }

        public ICollection<IEmployee> SubordinateEmployees { get; set; }

        public Manager(string firstName, string lastName) : this(firstName, lastName, null)
        {
        }
    }
}
