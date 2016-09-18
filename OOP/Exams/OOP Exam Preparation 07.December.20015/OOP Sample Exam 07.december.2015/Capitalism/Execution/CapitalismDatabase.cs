using Capitalism.Interfaces;
using Capitalism.Models;
using System.Collections.Generic;
using Capitalism.Models.Interfaces;

namespace Capitalism.Execution
{
    public class CapitalismDatabase : IDatabase
    {
        public CapitalismDatabase()
        {
            this.Companies = new List<Company>();
            this.TotalSalaries = new Dictionary<IPaidPerson, decimal>();
        }
        public ICollection<Company> Companies { get; private set; }
        public IDictionary<IPaidPerson, decimal> TotalSalaries { get; private set; }
    }
}
