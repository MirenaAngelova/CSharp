using System.Collections.Generic;
using Capitalism.Models;
using Capitalism.Models.Interfaces;

namespace Capitalism.Interfaces
{
    public interface IDatabase
    {
        ICollection<Company> Companies { get; }
        IDictionary<IPaidPerson, decimal> TotalSalaries { get; }
    }
}