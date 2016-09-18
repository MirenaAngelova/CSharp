using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Company_Hierarchy
{
    interface IProject
    {
        string ProjectName { get; }
        DateTime ProjectStartDate { get; }
        string Details { get; }
        ProjectState State { get; }
        void CloseProject();
    }
}
