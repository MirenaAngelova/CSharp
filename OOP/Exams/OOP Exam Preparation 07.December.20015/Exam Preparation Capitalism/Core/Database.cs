using System.Collections.Generic;

namespace Exam_Preparation_Capitalism
{
    using Interfaces;

    public class Database : IDatabase
    {
        private readonly IList<IOrganizationalUnits> companies;

        public Database()
        {
            this.companies = new List<IOrganizationalUnits>();

        }
        public IEnumerable<IOrganizationalUnits> Companies {get { return this.companies; } }

        public void AddCompanies(IOrganizationalUnits company)
        {
            this.companies.Add(company);
        }
    }
}
