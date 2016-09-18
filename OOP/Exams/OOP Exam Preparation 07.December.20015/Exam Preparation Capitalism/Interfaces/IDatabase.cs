using System.Collections.Generic;

namespace Exam_Preparation_Capitalism.Interfaces
{
    public interface IDatabase
    {
        IEnumerable<IOrganizationalUnits> Companies { get; }
        void AddCompanies(IOrganizationalUnits company);
    }
}