﻿namespace Exam_Preparation_Capitalism.Models.Employees
{
    using Interfaces;
    public class CEO : Employee
    {
        private const decimal SalaryFactorDefault = 0m;
        public CEO(string firstName, string lastName, IOrganizationalUnits inUnit, decimal salary) 
            : base(firstName, lastName, inUnit, SalaryFactorDefault)
        {
            this.Salary = salary;
        }

        public decimal Salary { get; set; }

        public override decimal RecieveSalary(decimal percents, decimal ceoSalary)
        {
            this.TotalPaid += this.Salary;
            return this.Salary;
        }
    }
}
