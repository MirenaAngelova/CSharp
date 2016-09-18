namespace Exam_Preparation_Capitalism.Models.Employees
{
    using Interfaces;
    public class Accountant : Employee
    {
        private const decimal SalaryFactorDefault = 0; 
        public Accountant(string firstName, string lastName, IOrganizationalUnits inUnit) 
            : base(firstName, lastName, inUnit, SalaryFactorDefault)
        {
        }
    }
}
