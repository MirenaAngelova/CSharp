using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Company_Hierarchy
{
    class Developer : RegularEmployee, IDeveloper
    {
        public Developer(string firstName, string lastName, int id, decimal salary, Department department,
            List<IProject> projects )
            : base(firstName, lastName, id, salary, department)
        {
            this.Projects = projects;
        }
        public Developer(string firstName, string lastName, int id, decimal salary, Department department,
           IProject project)
            : this(firstName, lastName, id, salary, department, new List<IProject>{ project })
        {
        }

        public List<IProject> Projects { get; private set; }
        public override string ToString()
        {
            StringBuilder exit = new StringBuilder();
            exit.Append(base.ToString());
            exit.Append(string.Format("Developer{0}Projects: {1}{0}", Environment.NewLine, this.Projects.Count));
            foreach (var project in this.Projects)
            {
                exit.Append(project.ToString());
            }
             return exit.ToString();
        }
    }
}
