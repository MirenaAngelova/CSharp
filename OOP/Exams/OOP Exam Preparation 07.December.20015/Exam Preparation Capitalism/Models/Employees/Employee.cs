namespace Exam_Preparation_Capitalism.Models
{
    using Interfaces;
    public class Employee : IEmployee
    {
        private string firstName;
        private string lastName;
        private IOrganizationalUnits inUnit;
        private decimal salaryFactor;

        public Employee(
            string firstName, 
            string lastName, 
            IOrganizationalUnits inUnit,
            decimal salaryFactor)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.InUnit = inUnit;
            this.SalaryFactor = salaryFactor;
        }

        public decimal SalaryFactor { get; protected set; }

        public IOrganizationalUnits InUnit { get; set; }

        public string LastName { get; protected set; }

        public string FirstName { get; protected set; }
        public decimal TotalPaid { get; set; }

        public virtual decimal RecieveSalary(decimal percents, decimal ceoSalary)
        {
            decimal toPay = percents*ceoSalary;
            toPay = toPay + toPay*this.salaryFactor;
            this.TotalPaid += toPay;
            return toPay;
        }
    }
}
