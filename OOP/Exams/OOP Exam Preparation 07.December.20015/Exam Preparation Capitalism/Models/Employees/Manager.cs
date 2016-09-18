namespace Exam_Preparation_Capitalism.Models.Employees
{
    using Interfaces;
    class Manager:Employee
    {
        private const int SalaryFactorDefault = 0;
        public Manager(string firstName, string lastName, IOrganizationalUnits inUnit)
            : base(firstName, lastName, inUnit, SalaryFactorDefault)
        {
        }
    }
}
