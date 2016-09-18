namespace Capitalism.Models
{
    public class Accountants : Employee
    {
        public Accountants(string firstName, string lastName, Department department) : 
            base(firstName, lastName, department)
        {
        }

        public Accountants(string firstName, string lastName) : base(firstName, lastName)
        {
        }
    }
}
