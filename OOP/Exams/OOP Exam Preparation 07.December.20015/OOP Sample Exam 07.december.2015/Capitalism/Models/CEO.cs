using System.Collections.Generic;
using Capitalism.Models.Interfaces;

namespace Capitalism.Models
{
    public class CEO : PaidPerson, IBoss
    {
        public CEO(string firstName, string lastName, decimal salary) : base(firstName, lastName)
        {
            this.SubordinateEmployees = new List<IEmployee>();
            this.Salary = salary;
        }
        public ICollection<IEmployee> SubordinateEmployees { get; set; }
    }
}
