using System.Collections.Generic;

namespace _03.Company_Hierarchy
{
    interface ISalesEmployee : IEmployee
    {
        List<ISale> Sales { get; } 
    }
}
