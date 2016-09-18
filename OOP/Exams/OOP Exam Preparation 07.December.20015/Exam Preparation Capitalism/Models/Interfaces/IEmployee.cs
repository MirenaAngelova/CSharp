using System.Collections.Generic;

namespace Exam_Preparation_Capitalism.Interfaces
{
    public interface IEmployee
    {
        string FirstName { get; }
        string LastName { get; }
        IOrganizationalUnits InUnit { get; set; }
        decimal SalaryFactor { get; }
        decimal TotalPaid { get; set; }

        decimal RecieveSalary(decimal percents, decimal ceoSalary);
    }
}