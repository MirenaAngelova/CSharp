namespace Exam_Preparation_Capitalism.Models.Employees
{
    using Interfaces;
    public class CleaningLady:Employee
    {
        private const decimal SalaryFactorDefault = 0;
        public CleaningLady(string firstName, string lastName, IOrganizationalUnits inUnit)
            : base(firstName, lastName, inUnit, SalaryFactorDefault)
        {
        }
    }
}
