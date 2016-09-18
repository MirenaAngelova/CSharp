namespace Capitalism.Models
{
    class ChiefTelephoneOfficers : Employee
    {
        private const double ChiefTelephoneOfficersSalaryFactor = 0.98; 
        public ChiefTelephoneOfficers(string firstName, string lastName, Department department) 
            : base(firstName, lastName, department)
        {
        }

        public ChiefTelephoneOfficers(string firstName, string lastName) : base(firstName, lastName)
        {
        }

        public override double SalaryFactor
        {
            get { return ChiefTelephoneOfficersSalaryFactor; }
        }
    }
}
