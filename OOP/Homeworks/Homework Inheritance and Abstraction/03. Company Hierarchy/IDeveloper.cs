using System.Collections.Generic;

namespace _03.Company_Hierarchy
{
    interface IDeveloper : IEmployee
    {
        List<IProject> Projects { get; } 
    }
}
