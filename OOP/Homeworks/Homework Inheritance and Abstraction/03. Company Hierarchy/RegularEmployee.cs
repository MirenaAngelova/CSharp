
namespace _03.Company_Hierarchy
{
    class RegularEmployee : Employee
    {
        public RegularEmployee(string firstName, string lastName, int id, decimal salary, Department department)
            : base(firstName, lastName, id, salary, department)
        {
        }
    }
}
