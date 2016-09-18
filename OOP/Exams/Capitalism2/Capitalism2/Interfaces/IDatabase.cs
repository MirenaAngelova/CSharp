namespace Capitalism2.Interfaces
{
    using System.Collections.Generic;

    using Models.Interfaces;

    public interface IDatabase
    {
        IEnumerable<IOrganizationalUnit> Companies { get; }

        void AddCompany(IOrganizationalUnit company);
    }
}