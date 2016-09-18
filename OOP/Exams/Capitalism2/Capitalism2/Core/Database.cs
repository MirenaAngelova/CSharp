namespace Capitalism2.Core
{
    using System.Collections.Generic;

    using Interfaces;
    using Models.Interfaces;

    public class Database : IDatabase
    {
        private readonly IList<IOrganizationalUnit> companies;

        public Database()
        {
            this.companies = new List<IOrganizationalUnit>();
        }

        public IEnumerable<IOrganizationalUnit> Companies => this.companies;

        public void AddCompany(IOrganizationalUnit company)
        {
            this.companies.Add(company);
        }
    }
}
