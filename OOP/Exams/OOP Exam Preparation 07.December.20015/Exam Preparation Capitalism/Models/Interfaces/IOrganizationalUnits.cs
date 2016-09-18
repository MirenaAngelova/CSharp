using System.Collections.Generic;

namespace Exam_Preparation_Capitalism.Interfaces
{
    public interface IOrganizationalUnits
    {
        string Name { get;  }
        IEnumerable<IOrganizationalUnits> SubUnits { get; }
        IEnumerable<IEmployee> Employees { get; }
        IEmployee Head { get; set; }

        void AddSubUnit(IOrganizationalUnits unit);
        void AddEmployee(IEmployee employee);
        void RemoveEmployee(IEmployee employee);
    }
}