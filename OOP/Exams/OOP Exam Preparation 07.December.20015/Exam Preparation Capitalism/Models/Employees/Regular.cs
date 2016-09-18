namespace Exam_Preparation_Capitalism.Models.Employees
{
    using Interfaces;

    public class Regular:Employee
    {
        private const decimal SalaryFactorDefault = 0;
        public Regular(string firstName, string lastName, IOrganizationalUnits inUnit)
            : base(firstName, lastName, inUnit, SalaryFactorDefault)
        {
        }
    }
}
