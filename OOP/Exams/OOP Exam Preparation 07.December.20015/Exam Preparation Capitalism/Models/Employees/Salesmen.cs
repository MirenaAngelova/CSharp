namespace Exam_Preparation_Capitalism.Models.Employees
{
    using Interfaces;
    public class Salesmen:Employee
    {
        private const decimal SalaryFactorDefault = 0;
        public Salesmen(string firstName, string lastName, IOrganizationalUnits inUnit) 
            : base(firstName, lastName, inUnit, SalaryFactorDefault)
        {
        }
    }
}
