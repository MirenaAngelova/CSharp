using System.Collections.Generic;

namespace Air_Conditioner_Testing_System.Interfaces
{
    public interface IReportsRepository : IRepository<IReport>
    {
        IList<IReport> GetReportsByManufacturer(string manufacturer);
    }
}