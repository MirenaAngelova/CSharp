using System.Collections.Generic;

namespace Air_Conditioner_Testing_System6.Interfaces
{
    public interface IReportsRepository : IRepository<IReport>
    {
        IList<IReport> GetReportsByManufacturer(string manufacturer);
    }
}