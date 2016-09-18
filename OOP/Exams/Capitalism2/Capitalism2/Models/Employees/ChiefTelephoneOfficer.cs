namespace Capitalism2.Models.Employees
{
    using Interfaces;

    public class ChiefTelephoneOfficer : Employee
    {
        private const decimal SalaryFactorDefault = -0.02m;

        public ChiefTelephoneOfficer(string firstName, string lastName, IOrganizationalUnit inUnit)
            : base(firstName, lastName, inUnit, SalaryFactorDefault)
        {
        }
    }
}
