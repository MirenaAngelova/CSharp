using System.Collections.Generic;

namespace _03.Company_Hierarchy
{
    interface IManager : IEmployee
    {
        List<IEmployee> Staff { get; } 
    }
}
