using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam_Preparation_Capitalism.Interfaces;
using Exam_Preparation_Capitalism.Models.Employees;
using Exam_Preparation_Capitalism.OrganizationalUnits;
using Microsoft.SqlServer.Server;

namespace Exam_Preparation_Capitalism.Core.Commands
{
    public class CreateDepartmentCommand : CommandAbstract
    {
        private string companyName;
        private string departmentName;
        private string managerFirstName;
        private string managerLastName;
        private decimal managerSalary;
        private string mainDepartmentName;
        public CreateDepartmentCommand(
            IDatabase db,
            string companyName,
            string departmentName,
            string managerFirstName,
            string managerLastName,
            decimal managerSalary,
            string mainDepartmentName = null)
            : base(db)
        {
            this.companyName = companyName;
            this.departmentName = departmentName;
            this.managerFirstName = managerFirstName;
            this.managerLastName = managerLastName;
            this.managerSalary = managerSalary;
            this.mainDepartmentName = mainDepartmentName;
        }

        public override string Execute()
        {
            Company company = null;
            foreach (Company c in this.db.Companies)
            {
                if (c.Name == this.companyName)
                {
                    company = c;
                    break;
                }
            }
            if (company == null)
            {
                throw new Exception(string.Format("Company {0} does not exist", this.companyName));
            }

            foreach (IOrganizationalUnits d in company.SubUnits)
            {
                if (d.Name == this.departmentName)
                {
                    throw new Exception(string.
                        Format("Department {0} already exists in {1}",
                        this.departmentName,
                        company.Name
                        ));
                }
            }
            IEmployee manager = null;
            foreach (IEmployee m in company.Employees)
            {
                if (m.FirstName == this.managerFirstName && m.LastName == this.managerLastName)
                {
                    manager = m;
                }
            }
            if (manager == null)
            {
                throw new ArgumentException(
                    string.Format(
                    "There is no employee called {0} {1} in company {2}",
                    this.managerFirstName, 
                    this.managerLastName, 
                    this.companyName));
            }
            if (!manager is Manager)
            {
                
            }
        }
    }
}
