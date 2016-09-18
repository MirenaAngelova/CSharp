using Capitalism.Models;
using Capitalism.Models.Interfaces;

namespace Capitalism.Salaries
{
    public class SalaryManager
    {
        public decimal GetSalary(IEmployee employee, Company company)
        {
            return (decimal) employee.SalaryFactor*GetSalaryPercentage(employee, company)*company.CEO.Salary;
        }

        private decimal GetSalaryPercentage(IEmployee employee, Company company)
        {
            decimal salaryPecentage = 0.15m;
            if (employee.Department == null)
            {
                return salaryPecentage;
            }
            salaryPecentage = GetSalaryPercentage(employee.Department.Manager, company) - 0.01m;
            return salaryPecentage;
        }
    }
}
