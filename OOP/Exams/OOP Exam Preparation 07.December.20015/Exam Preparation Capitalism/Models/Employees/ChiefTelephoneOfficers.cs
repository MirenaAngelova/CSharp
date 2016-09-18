namespace Exam_Preparation_Capitalism.Models.Employees
{
    using Interfaces;
    public class ChiefTelephoneOfficers:Employee
    {
        private const decimal SalaryFactorDefault = 0;
        public ChiefTelephoneOfficers(string firstName, string lastName, IOrganizationalUnits inUnit) 
            : base(firstName, lastName, inUnit, SalaryFactorDefault)
        {
        }
    }
}
